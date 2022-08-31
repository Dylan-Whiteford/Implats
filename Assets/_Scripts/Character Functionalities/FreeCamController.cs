using System;
using UnityEngine;
using Normal.Realtime;

    /// <summary>
    /// Controller script for a free cam user
    /// </summary>
    [RealtimeModel]
    public class FreeCamController : MonoBehaviour {
        public static FreeCamController instance;
        // Camera
        public  Transform  cameraTarget;
        private float     _mouseLookX;
        private float     _mouseLookY;

        
        // Physics
        
        private Vector3   _targetMovement;
        private Vector3   _movement;
        
        private Rigidbody _rigidbody;
        private RealtimeView _realtimeView;

        // User
        [SerializeField] private Transform _character = default;

        //Highlight
        private int actorMask;
        private int highlightMask;

        private GameObject currentTarget;
        private Vector3 screenCenter;
        public Camera camera;


        // Body
        public GameObject head;
        private RaycastHit info;

        private void Awake() {
            // Check for singleton
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            } else {
                instance = this;
            }

            // Set physics timestep to 60hz
            Time.fixedDeltaTime = 1.0f/60.0f;

            // Store a reference to the rigidbody for easy access
            _rigidbody = GetComponent<Rigidbody>();

            // Store a reference to the RealtimeView for easy access
            _realtimeView = GetComponent<RealtimeView>();


            //Highlight
            actorMask = LayerMask.NameToLayer("Actor");
            highlightMask = LayerMask.NameToLayer("Highlight");

            screenCenter = new Vector3(Screen.width >> 1, Screen.height>>1);
        }
        private void Start() {

            // Call LocalStart() only if this instance is owned by the local client
            if (_realtimeView.isOwnedLocallyInHierarchy)
                LocalStart();
        }
        private void LocalStart() {
                // Request ownership of the Player and the character RealtimeTransforms
                GetComponent<RealtimeTransform>().RequestOwnership();
                _character.GetComponent<RealtimeTransform>().RequestOwnership();
        }
        private void Update() {
            // Move the camera using the mouse
            RotateCamera();

            // Use WASD input and the camera look direction to calculate the movement target
            CalculateTargetMovement();


            // Check if user is clicking on a location node
            if(currentTarget!= null && currentTarget.TryGetComponent<ItemObject>(out ItemObject item)){
                
                if (Input.GetButtonDown("Fire1")){
                    Debug.Log("Picked Up Item");
                
                    item.OnHandlePickUpItem();  
                }

            }
            else if(currentTarget!= null){
                if (Input.GetButtonDown("Fire1")){
                    this.transform.position = info.transform.position;
                    Debug.Log(info);
                }
            }

        }

        private void FixedUpdate() {
            // Move the player based on the input
            MovePlayer();


            Vector3 fwd = cameraTarget.TransformDirection(Vector3.forward);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(screenCenter), out info, 10.0f, LayerMask.GetMask("Actor","Highlight"))){
                
                GameObject target = info.collider.gameObject;


                if(currentTarget!=target){
                   // OnHoverNewTarget.Invoke(target);
                    if(currentTarget!=null){
                        currentTarget.layer = actorMask;
                    }
                    currentTarget = target;
                    currentTarget.layer = highlightMask;
                }
            }
            else if(currentTarget!=null){
                currentTarget.layer = actorMask;
               // OnExitHover?.Invoke(currentTarget);
                currentTarget = null;
            }


        }

        private void RotateCamera() {
            // Get the latest mouse movement. Multiple by 4.0 to increase sensitivity.
            _mouseLookX += Input.GetAxis("Mouse X") * 4.0f;
            _mouseLookY += Input.GetAxis("Mouse Y") * 4.0f;

            // Clamp how far you can look up + down
            while (_mouseLookY < -180.0f) _mouseLookY += 360.0f;
            while (_mouseLookY >  180.0f) _mouseLookY -= 360.0f;
            _mouseLookY = Mathf.Clamp(_mouseLookY, -30.0f, 30.0f);

            // Rotate camera
            cameraTarget.localRotation = Quaternion.Euler(-_mouseLookY, _mouseLookX, 0.0f);
        }

        private void CalculateTargetMovement() {
            // Get input movement. Multiple by 6.0 to increase speed.
            Vector3 inputMovement = new Vector3();
            inputMovement.x = Input.GetAxisRaw("Horizontal") * 6.0f;
            inputMovement.z = Input.GetAxisRaw("Vertical")   * 6.0f;

            // Get the direction the camera is looking parallel to the ground plane.
            Vector3    cameraLookForwardVector = ProjectVectorOntoGroundPlane(cameraTarget.forward);
            Quaternion cameraLookForward       = Quaternion.LookRotation(cameraLookForwardVector);

            // Use the camera look direction to convert the input movement from camera space to world space
            _targetMovement = cameraLookForward * inputMovement;
        }

        private void MovePlayer() {
            // Start with the current velocity
            Vector3 velocity = _rigidbody.velocity;

            // Smoothly animate towards the target movement velocity
            _movement = Vector3.Lerp(_movement, _targetMovement, Time.fixedDeltaTime * 5.0f);
            velocity.x = _movement.x;
            velocity.z = _movement.z;

            
            // Set the velocity on the rigidbody
            _rigidbody.velocity = velocity;
        }
        // Given a forward vector, get a y-axis rotation that points in the same direction that's parallel to the ground plane
        private static Vector3 ProjectVectorOntoGroundPlane(Vector3 vector) {
            Vector3 planeNormal = Vector3.up;
            Vector3.OrthoNormalize(ref planeNormal, ref vector);
            return vector;
        }




    }

    


