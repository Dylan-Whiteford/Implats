using UnityEditor;
using System.IO;

public class CreateAssetBundlesFunctions
{
	[MenuItem("Assets/Build AssetBundles/Android")]
	public static void BuildAllAndroidAssetBundles()
	{
		string assetBundleDirectory = Path.Combine("Assets", "AssetBundles", "Android");
		if (!Directory.Exists(assetBundleDirectory))
			Directory.CreateDirectory(assetBundleDirectory);

		BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
	}

	[MenuItem("Assets/Build AssetBundles/iOS")]
	public static void BuildAlliOSAssetBundles()
	{
		string assetBundleDirectory = Path.Combine("Assets", "AssetBundles", "iOS");
		if (!Directory.Exists(assetBundleDirectory))
			Directory.CreateDirectory(assetBundleDirectory);

		BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.iOS);
	}

	[MenuItem("Assets/Build AssetBundles/WebGL")]
	public static void BuildAllWebGLAssetBundles()
	{
		string assetBundleDirectory = Path.Combine("Assets", "AssetBundles", "WebGL");
		if (!Directory.Exists(assetBundleDirectory))
			Directory.CreateDirectory(assetBundleDirectory);

		BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.WebGL);
	}
}