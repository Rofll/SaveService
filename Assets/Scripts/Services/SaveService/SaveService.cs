using UnityEngine;

public class SaveService : ISaveService
{
    public SaveService()
    {
        instance = this;
    }

    private SaveService instance;
    public SaveService Instance {
        get 
        {
            if (instance == null)
            {
                instance = new SaveService();
            }

            return instance;
        }
    }

    private ISavePalyerPrefs savePalyerPrefs = new SavePlayerPrefs();
    private ILoadPalyerPrefs loadPalyerPrefs = new LoadPlayerPrefs();
    private ISaveFile saveJson = new SaveJson();
    private ILoadFile loadJson = new LoadJoson();
    private ISaveFile saveBinary = new SaveBinary();
    private ILoadFile loadBinary = new LoadBinary();

 
    public void Save<T>(string key, T saveItem, ESaveFormat saveFormat = ESaveFormat.PlayerPrefs, string filePath = null)
    {
        if (saveFormat == ESaveFormat.PlayerPrefs)
        {
            savePalyerPrefs.Save(key, saveItem);
        }

        else if (saveFormat == ESaveFormat.Json)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Debug.LogError("FilePath = nullOrEmpty!");
                return;
            }
            
            saveJson.Save(key, saveItem, filePath);
        }

        else if (saveFormat == ESaveFormat.Binary)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Debug.LogError("FilePath = nullOrEmpty!");
                return;
            }

            saveBinary.Save(key, saveItem, filePath);
        }
    }

    public T Load<T>(string key, ESaveFormat saveFormat = ESaveFormat.PlayerPrefs, string filePath = null)
    {

        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("Key = nullOrEmpty!");
            return default;
        }

        if (saveFormat == ESaveFormat.PlayerPrefs)
        {
            return loadPalyerPrefs.Load<T>(key);
        }

        else if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("FilePath = nullOrEmpty!");
            return default;

        }

        else
        {
            if (saveFormat == ESaveFormat.Json)
            {
                return loadJson.Load<T>(key, filePath);
            }

            else if (saveFormat == ESaveFormat.Binary)
            {
                return loadBinary.Load<T>(key, filePath);
            }
        }

        Debug.LogError("No SaveFormat chosen!");
        return default;
    }
}
