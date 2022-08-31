using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class NetworkedPlayerModel
{
    [RealtimeProperty(1, true, true)] bool _isHost = false; 
    [RealtimeProperty(2, true, true)] int _id = 99; 
    [RealtimeProperty(3, true, true)] string _created_at;
    [RealtimeProperty(4, true, true)] string _first_name;
    [RealtimeProperty(5, true, true)] string _second_name;
    [RealtimeProperty(6, true, true)] string _email_address;
    [RealtimeProperty(7, true, true)] string _id_number;
    [RealtimeProperty(8, true, true)] int _user_type_id;
    [RealtimeProperty(9, true, true)] string _user_type;
    [RealtimeProperty(10, true, true)] int _company_id;
    [RealtimeProperty(11, true, true)] string _company_name;
    [RealtimeProperty(12, true, true)] int _player_index;
    [RealtimeProperty(13, true, true)] int _voiceChannel;
    [RealtimeProperty(14, true, true)] string _ppe;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class NetworkedPlayerModel : RealtimeModel {
    public bool isHost {
        get {
            return _isHostProperty.value;
        }
        set {
            if (_isHostProperty.value == value) return;
            _isHostProperty.value = value;
            InvalidateReliableLength();
            FireIsHostDidChange(value);
        }
    }
    
    public int id {
        get {
            return _idProperty.value;
        }
        set {
            if (_idProperty.value == value) return;
            _idProperty.value = value;
            InvalidateReliableLength();
            FireIdDidChange(value);
        }
    }
    
    public string created_at {
        get {
            return _created_atProperty.value;
        }
        set {
            if (_created_atProperty.value == value) return;
            _created_atProperty.value = value;
            InvalidateReliableLength();
            FireCreated_atDidChange(value);
        }
    }
    
    public string first_name {
        get {
            return _first_nameProperty.value;
        }
        set {
            if (_first_nameProperty.value == value) return;
            _first_nameProperty.value = value;
            InvalidateReliableLength();
            FireFirst_nameDidChange(value);
        }
    }
    
    public string second_name {
        get {
            return _second_nameProperty.value;
        }
        set {
            if (_second_nameProperty.value == value) return;
            _second_nameProperty.value = value;
            InvalidateReliableLength();
            FireSecond_nameDidChange(value);
        }
    }
    
    public string email_address {
        get {
            return _email_addressProperty.value;
        }
        set {
            if (_email_addressProperty.value == value) return;
            _email_addressProperty.value = value;
            InvalidateReliableLength();
            FireEmail_addressDidChange(value);
        }
    }
    
    public string id_number {
        get {
            return _id_numberProperty.value;
        }
        set {
            if (_id_numberProperty.value == value) return;
            _id_numberProperty.value = value;
            InvalidateReliableLength();
            FireId_numberDidChange(value);
        }
    }
    
    public int user_type_id {
        get {
            return _user_type_idProperty.value;
        }
        set {
            if (_user_type_idProperty.value == value) return;
            _user_type_idProperty.value = value;
            InvalidateReliableLength();
            FireUser_type_idDidChange(value);
        }
    }
    
    public string user_type {
        get {
            return _user_typeProperty.value;
        }
        set {
            if (_user_typeProperty.value == value) return;
            _user_typeProperty.value = value;
            InvalidateReliableLength();
            FireUser_typeDidChange(value);
        }
    }
    
    public int company_id {
        get {
            return _company_idProperty.value;
        }
        set {
            if (_company_idProperty.value == value) return;
            _company_idProperty.value = value;
            InvalidateReliableLength();
            FireCompany_idDidChange(value);
        }
    }
    
    public string company_name {
        get {
            return _company_nameProperty.value;
        }
        set {
            if (_company_nameProperty.value == value) return;
            _company_nameProperty.value = value;
            InvalidateReliableLength();
            FireCompany_nameDidChange(value);
        }
    }
    
    public int player_index {
        get {
            return _player_indexProperty.value;
        }
        set {
            if (_player_indexProperty.value == value) return;
            _player_indexProperty.value = value;
            InvalidateReliableLength();
            FirePlayer_indexDidChange(value);
        }
    }
    
    public int voiceChannel {
        get {
            return _voiceChannelProperty.value;
        }
        set {
            if (_voiceChannelProperty.value == value) return;
            _voiceChannelProperty.value = value;
            InvalidateReliableLength();
            FireVoiceChannelDidChange(value);
        }
    }
    
    public string ppe {
        get {
            return _ppeProperty.value;
        }
        set {
            if (_ppeProperty.value == value) return;
            _ppeProperty.value = value;
            InvalidateReliableLength();
            FirePpeDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(NetworkedPlayerModel model, T value);
    public event PropertyChangedHandler<bool> isHostDidChange;
    public event PropertyChangedHandler<int> idDidChange;
    public event PropertyChangedHandler<string> created_atDidChange;
    public event PropertyChangedHandler<string> first_nameDidChange;
    public event PropertyChangedHandler<string> second_nameDidChange;
    public event PropertyChangedHandler<string> email_addressDidChange;
    public event PropertyChangedHandler<string> id_numberDidChange;
    public event PropertyChangedHandler<int> user_type_idDidChange;
    public event PropertyChangedHandler<string> user_typeDidChange;
    public event PropertyChangedHandler<int> company_idDidChange;
    public event PropertyChangedHandler<string> company_nameDidChange;
    public event PropertyChangedHandler<int> player_indexDidChange;
    public event PropertyChangedHandler<int> voiceChannelDidChange;
    public event PropertyChangedHandler<string> ppeDidChange;
    
    public enum PropertyID : uint {
        IsHost = 1,
        Id = 2,
        Created_at = 3,
        First_name = 4,
        Second_name = 5,
        Email_address = 6,
        Id_number = 7,
        User_type_id = 8,
        User_type = 9,
        Company_id = 10,
        Company_name = 11,
        Player_index = 12,
        VoiceChannel = 13,
        Ppe = 14,
    }
    
    #region Properties
    
    private ReliableProperty<bool> _isHostProperty;
    
    private ReliableProperty<int> _idProperty;
    
    private ReliableProperty<string> _created_atProperty;
    
    private ReliableProperty<string> _first_nameProperty;
    
    private ReliableProperty<string> _second_nameProperty;
    
    private ReliableProperty<string> _email_addressProperty;
    
    private ReliableProperty<string> _id_numberProperty;
    
    private ReliableProperty<int> _user_type_idProperty;
    
    private ReliableProperty<string> _user_typeProperty;
    
    private ReliableProperty<int> _company_idProperty;
    
    private ReliableProperty<string> _company_nameProperty;
    
    private ReliableProperty<int> _player_indexProperty;
    
    private ReliableProperty<int> _voiceChannelProperty;
    
    private ReliableProperty<string> _ppeProperty;
    
    #endregion
    
    public NetworkedPlayerModel() : base(null) {
        _isHostProperty = new ReliableProperty<bool>(1, _isHost);
        _idProperty = new ReliableProperty<int>(2, _id);
        _created_atProperty = new ReliableProperty<string>(3, _created_at);
        _first_nameProperty = new ReliableProperty<string>(4, _first_name);
        _second_nameProperty = new ReliableProperty<string>(5, _second_name);
        _email_addressProperty = new ReliableProperty<string>(6, _email_address);
        _id_numberProperty = new ReliableProperty<string>(7, _id_number);
        _user_type_idProperty = new ReliableProperty<int>(8, _user_type_id);
        _user_typeProperty = new ReliableProperty<string>(9, _user_type);
        _company_idProperty = new ReliableProperty<int>(10, _company_id);
        _company_nameProperty = new ReliableProperty<string>(11, _company_name);
        _player_indexProperty = new ReliableProperty<int>(12, _player_index);
        _voiceChannelProperty = new ReliableProperty<int>(13, _voiceChannel);
        _ppeProperty = new ReliableProperty<string>(14, _ppe);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _isHostProperty.UnsubscribeCallback();
        _idProperty.UnsubscribeCallback();
        _created_atProperty.UnsubscribeCallback();
        _first_nameProperty.UnsubscribeCallback();
        _second_nameProperty.UnsubscribeCallback();
        _email_addressProperty.UnsubscribeCallback();
        _id_numberProperty.UnsubscribeCallback();
        _user_type_idProperty.UnsubscribeCallback();
        _user_typeProperty.UnsubscribeCallback();
        _company_idProperty.UnsubscribeCallback();
        _company_nameProperty.UnsubscribeCallback();
        _player_indexProperty.UnsubscribeCallback();
        _voiceChannelProperty.UnsubscribeCallback();
        _ppeProperty.UnsubscribeCallback();
    }
    
    private void FireIsHostDidChange(bool value) {
        try {
            isHostDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIdDidChange(int value) {
        try {
            idDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireCreated_atDidChange(string value) {
        try {
            created_atDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireFirst_nameDidChange(string value) {
        try {
            first_nameDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireSecond_nameDidChange(string value) {
        try {
            second_nameDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireEmail_addressDidChange(string value) {
        try {
            email_addressDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireId_numberDidChange(string value) {
        try {
            id_numberDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireUser_type_idDidChange(int value) {
        try {
            user_type_idDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireUser_typeDidChange(string value) {
        try {
            user_typeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireCompany_idDidChange(int value) {
        try {
            company_idDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireCompany_nameDidChange(string value) {
        try {
            company_nameDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FirePlayer_indexDidChange(int value) {
        try {
            player_indexDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireVoiceChannelDidChange(int value) {
        try {
            voiceChannelDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FirePpeDidChange(string value) {
        try {
            ppeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _isHostProperty.WriteLength(context);
        length += _idProperty.WriteLength(context);
        length += _created_atProperty.WriteLength(context);
        length += _first_nameProperty.WriteLength(context);
        length += _second_nameProperty.WriteLength(context);
        length += _email_addressProperty.WriteLength(context);
        length += _id_numberProperty.WriteLength(context);
        length += _user_type_idProperty.WriteLength(context);
        length += _user_typeProperty.WriteLength(context);
        length += _company_idProperty.WriteLength(context);
        length += _company_nameProperty.WriteLength(context);
        length += _player_indexProperty.WriteLength(context);
        length += _voiceChannelProperty.WriteLength(context);
        length += _ppeProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _isHostProperty.Write(stream, context);
        writes |= _idProperty.Write(stream, context);
        writes |= _created_atProperty.Write(stream, context);
        writes |= _first_nameProperty.Write(stream, context);
        writes |= _second_nameProperty.Write(stream, context);
        writes |= _email_addressProperty.Write(stream, context);
        writes |= _id_numberProperty.Write(stream, context);
        writes |= _user_type_idProperty.Write(stream, context);
        writes |= _user_typeProperty.Write(stream, context);
        writes |= _company_idProperty.Write(stream, context);
        writes |= _company_nameProperty.Write(stream, context);
        writes |= _player_indexProperty.Write(stream, context);
        writes |= _voiceChannelProperty.Write(stream, context);
        writes |= _ppeProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.IsHost: {
                    changed = _isHostProperty.Read(stream, context);
                    if (changed) FireIsHostDidChange(isHost);
                    break;
                }
                case (uint) PropertyID.Id: {
                    changed = _idProperty.Read(stream, context);
                    if (changed) FireIdDidChange(id);
                    break;
                }
                case (uint) PropertyID.Created_at: {
                    changed = _created_atProperty.Read(stream, context);
                    if (changed) FireCreated_atDidChange(created_at);
                    break;
                }
                case (uint) PropertyID.First_name: {
                    changed = _first_nameProperty.Read(stream, context);
                    if (changed) FireFirst_nameDidChange(first_name);
                    break;
                }
                case (uint) PropertyID.Second_name: {
                    changed = _second_nameProperty.Read(stream, context);
                    if (changed) FireSecond_nameDidChange(second_name);
                    break;
                }
                case (uint) PropertyID.Email_address: {
                    changed = _email_addressProperty.Read(stream, context);
                    if (changed) FireEmail_addressDidChange(email_address);
                    break;
                }
                case (uint) PropertyID.Id_number: {
                    changed = _id_numberProperty.Read(stream, context);
                    if (changed) FireId_numberDidChange(id_number);
                    break;
                }
                case (uint) PropertyID.User_type_id: {
                    changed = _user_type_idProperty.Read(stream, context);
                    if (changed) FireUser_type_idDidChange(user_type_id);
                    break;
                }
                case (uint) PropertyID.User_type: {
                    changed = _user_typeProperty.Read(stream, context);
                    if (changed) FireUser_typeDidChange(user_type);
                    break;
                }
                case (uint) PropertyID.Company_id: {
                    changed = _company_idProperty.Read(stream, context);
                    if (changed) FireCompany_idDidChange(company_id);
                    break;
                }
                case (uint) PropertyID.Company_name: {
                    changed = _company_nameProperty.Read(stream, context);
                    if (changed) FireCompany_nameDidChange(company_name);
                    break;
                }
                case (uint) PropertyID.Player_index: {
                    changed = _player_indexProperty.Read(stream, context);
                    if (changed) FirePlayer_indexDidChange(player_index);
                    break;
                }
                case (uint) PropertyID.VoiceChannel: {
                    changed = _voiceChannelProperty.Read(stream, context);
                    if (changed) FireVoiceChannelDidChange(voiceChannel);
                    break;
                }
                case (uint) PropertyID.Ppe: {
                    changed = _ppeProperty.Read(stream, context);
                    if (changed) FirePpeDidChange(ppe);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _isHost = isHost;
        _id = id;
        _created_at = created_at;
        _first_name = first_name;
        _second_name = second_name;
        _email_address = email_address;
        _id_number = id_number;
        _user_type_id = user_type_id;
        _user_type = user_type;
        _company_id = company_id;
        _company_name = company_name;
        _player_index = player_index;
        _voiceChannel = voiceChannel;
        _ppe = ppe;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
