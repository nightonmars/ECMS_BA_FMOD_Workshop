using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class OpenProjectFMODSession : MonoBehaviour
{
    private const string FMODProjectPathKey = "FMOD_Project_Path";

    [MenuItem("Tools/Open FMOD Project")]
    [MenuItem("Tools/Open FMOD Project")]
    public static void OpenFMODProject()
    {
        string projectFullPath = EditorPrefs.GetString(FMODProjectPathKey, "");

        if (string.IsNullOrEmpty(projectFullPath) || !File.Exists(projectFullPath))
        {
            projectFullPath = EditorUtility.OpenFilePanel("Select FMOD Project (.fspro)", Directory.GetCurrentDirectory(), "fspro");
            if (string.IsNullOrEmpty(projectFullPath))
            {
                UnityEngine.Debug.LogWarning("No FMOD project selected.");
                return;
            }
            EditorPrefs.SetString(FMODProjectPathKey, projectFullPath);
        }

        LaunchFMOD(projectFullPath);
    }


    private static void LaunchFMOD(string projectPath)
    {
        string appPath = "/Applications/FMOD Studio.app";

#if UNITY_EDITOR_OSX
        Process.Start("/usr/bin/open", $"-a \"{appPath}\" \"{projectPath}\"");
#else
    // Windows version if needed
    string fmodExePath = @"C:\Program Files\FMOD Studio\FMOD Studio.exe";
    Process.Start(fmodExePath, $"\"{projectPath}\"");
#endif
    }
}