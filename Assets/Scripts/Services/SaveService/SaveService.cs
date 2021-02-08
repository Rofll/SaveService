using System.Collections.Generic;
using System.Threading.Tasks;
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
    //private ISaveFile saveProtoBuf = new SaveProtoBuf();
    //private ILoadFile loadProtoBuf = new LoadProtoBuf();


    public async Task Save<T>(string key, T saveItem, ESaveFormat saveFormat, string filePath = null)
    {
        if (saveFormat == ESaveFormat.PlayerPrefs)
        {
            savePalyerPrefs.Save(key, saveItem);
        }

        else if (!string.IsNullOrEmpty(filePath))
        {
            if (saveFormat == ESaveFormat.Json)
            {
                await saveJson.Save(key, saveItem, filePath);
            }

            else if (saveFormat == ESaveFormat.Binary)
            {
                await saveBinary.Save(key, saveItem, filePath);
            }

            //else if (saveFormat == ESaveFormat.ProtoBuf)
            //{
            //    await saveProtoBuf.Save(key, saveItem, filePath);
            //}
        }

        else
        {
            Debug.LogError("FilePath = nullOrEmpty!");
        }
    }

    public async Task Save(Dictionary<string, object> itemsDictionary, ESaveFormat saveFormat, string filePath = null)
    {
        if (saveFormat == ESaveFormat.PlayerPrefs)
        {
            savePalyerPrefs.Save(itemsDictionary);
        }

        else if (!string.IsNullOrEmpty(filePath))
        {
            if (saveFormat == ESaveFormat.Json)
            {
                await saveJson.Save(itemsDictionary, filePath);
            }

            else if (saveFormat == ESaveFormat.Binary)
            {
                await saveBinary.Save(itemsDictionary, filePath);
            }

            //else if (saveFormat == ESaveFormat.ProtoBuf)
            //{
            //    await saveProtoBuf.Save(itemsDictionary, filePath);
            //}
        }

        else
        {
            Debug.LogError("FilePath = nullOrEmpty!");
        }
    }

    public async Task<T> Load<T>(string key, ESaveFormat saveFormat, string filePath = null)
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
                return await loadJson.Load<T>(key, filePath);
            }

            else if (saveFormat == ESaveFormat.Binary)
            {
                return await loadBinary.Load<T>(key, filePath);
            }

            //else if (saveFormat == ESaveFormat.ProtoBuf)
            //{
            //    return await loadProtoBuf.Load<T>(key, filePath);
            //}
        }

        Debug.LogError("No SaveFormat chosen!");
        return default;
    }
}
