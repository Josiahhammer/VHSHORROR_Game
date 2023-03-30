using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;


public class SaveLoadManager : MonoBehaviour
{
    private static string SavePath => Application.persistentDataPath + "/savedata.json";
    private static string EncryptionKey = "SuperSecretEncryptionKey";

    public static void Save(PlayerSaveLoad data)
    {
        string json = JsonUtility.ToJson(data);
        string encryptedJson = XOREncrypt(json, EncryptionKey);
        File.WriteAllText(SavePath, encryptedJson);
    }

    public static PlayerSaveLoad Load()
    {
        if (!File.Exists(SavePath))
        {
            return null;
        }

        string encryptedJson = File.ReadAllText(SavePath);
        string json = XORDecrypt(encryptedJson, EncryptionKey);
        return JsonUtility.FromJson<PlayerSaveLoad>(json);
    }

    private static string XOREncrypt(string data, string key)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(data);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        int keyLength = keyBytes.Length;
        for (int ii = 0; ii < bytes.Length; ii++)
        {
            bytes[ii] = (byte)(bytes[ii] ^ keyBytes[ii % keyLength]);
        }
        return Convert.ToBase64String(bytes);
    }

    private static string XORDecrypt(string encryptedData, string key)
    {
        byte[] bytes = Convert.FromBase64String(encryptedData);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        int keyLength = keyBytes.Length;
        for (int ii = 0; ii < bytes.Length; ii++)
        {
            bytes[ii] = (byte)(bytes[ii] ^ keyBytes[ii % keyLength]);
        }
        return Encoding.UTF8.GetString(bytes);
    }
}
