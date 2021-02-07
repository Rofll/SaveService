using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

public class TestMonoBehaviour : MonoBehaviour
{
    ISaveService saveService = new SaveService();

    Test test = new Test();
    Test test2 = new Test();

    private ISavePalyerPrefs savePalyerPrefs = new SavePlayerPrefs();
    private ILoadPalyerPrefs loadPalyerPrefs = new LoadPlayerPrefs();
    private ISaveFile saveJson = new SaveJson();
    private ILoadFile loadJson = new LoadJoson();
    private ISaveFile saveBinary = new SaveBinary();
    private ILoadFile loadBinary = new LoadBinary();
    private ISaveFile saveProtoBuf = new SaveProtoBuf();
    private ILoadFile loadProtoBuf = new LoadProtoBuf();
    private ISavePool savePool = new SavePool();



    void Start()
    {
        test.Key = "test1";
        test2.Key = "test2";

        test.hp = 20;

        savePool.AddSaveItem(test.Key, test);
        savePool.AddSaveItem(test2.Key, test2);

        Debug.LogError("PlayerPrefs");
        savePalyerPrefs.Save(savePool.SaveDictionary);
        Debug.LogError(loadPalyerPrefs.Load<Test>(test.Key));

        Debug.LogError("JSon");
        saveJson.Save(savePool.SaveDictionary, Application.persistentDataPath + "/mainConfigFile");
        Debug.LogError(loadJson.Load<Test>(test.Key, Application.persistentDataPath + "/mainConfigFile"));

        Debug.LogError("Binary");
        saveBinary.Save(savePool.SaveDictionary, Application.persistentDataPath + "/mainConfigFile");
        Debug.LogError(loadBinary.Load<Test>(test.Key, Application.persistentDataPath + "/mainConfigFile"));

        Debug.LogError("ProtoBuf");
        saveProtoBuf.Save(savePool.SaveDictionary, Application.persistentDataPath + "/mainConfigFile");
        Debug.LogError(loadProtoBuf.Load<Test>(test.Key, Application.persistentDataPath + "/mainConfigFile"));
    }
}
