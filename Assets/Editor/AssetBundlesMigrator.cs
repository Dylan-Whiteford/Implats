using System.IO;
using UnityEditor;
using UnityEngine;

//[InitializeOnLoad]
public class AssetBundlesMigrator : MonoBehaviour
{
	static AssetBundlesMigrator()
	{
		OnScriptsReloaded();
	}

	//[UnityEditor.Callbacks.DidReloadScripts]
	public static void OnScriptsReloaded()
	{
		string assetBundlesPath = Path.Combine("Assets", "AssetBundles");
		CopyDirectories(assetBundlesPath, Application.streamingAssetsPath);
		CopyFiles(assetBundlesPath, Application.streamingAssetsPath);
	}

	public static void CopyDirectories(string source, string destination)
	{
		DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(source);
		foreach (DirectoryInfo directoryInfo in sourceDirectoryInfo.GetDirectories())
		{
			string innerDirectorySourcePath = Path.Combine(source, directoryInfo.Name);
			string innerDirectoryDestinationPath = Path.Combine(destination, directoryInfo.Name);
			if (!Directory.Exists(innerDirectoryDestinationPath))
				Directory.CreateDirectory(innerDirectoryDestinationPath);
			CopyDirectories(innerDirectorySourcePath, innerDirectoryDestinationPath);
			CopyFiles(innerDirectorySourcePath, innerDirectoryDestinationPath);
		}
	}

	public static void CopyFiles(string source, string destination)
	{
		DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(source);
		foreach (FileInfo fileInfo in sourceDirectoryInfo.GetFiles())
		{
			string fileDestinationPath = Path.Combine(destination, fileInfo.Name);
			if (!File.Exists(fileDestinationPath))
				File.Copy(Path.Combine(source, fileInfo.Name), fileDestinationPath, true);
		}
	}
}