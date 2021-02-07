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
    private ISavePool savePool = new SavePool();


    void Start()
    {
        //test2.Key = "andSomed";
        //test2.Name = "YURA";
        //saveService.Save(test.Key,test,ESaveFormat.Json, Application.persistentDataPath + "/mainConfigFile.json");
        //saveService.Save(test2.Key, test2, ESaveFormat.Json, Application.persistentDataPath + "/mainConfigFile.json");
        //saveService.Save(test.Key, test, ESaveFormat.Binary, Application.persistentDataPath + "/mainConfigFile.bin");
        //Debug.LogError(Application.persistentDataPath);
        //Test test3 = saveService.Load<Test>(test2.Key, ESaveFormat.Json, Application.persistentDataPath + "/mainConfigFile.json");
        //Debug.LogError(test3.Key);
        //Debug.LogError(saveService.Load<Test>(test.Key, ESaveFormat.Binary, Application.persistentDataPath + "/mainConfigFile.bin"));
        //saveService.Save("asd", 1);
        //Debug.LogError(saveService.Load<Test>(test.Key).ToString());
        //Debug.LogError(saveService.Load<int>("asd").ToString());

        test.Key = "test1";
        test2.Key = "test2";

        test.hp = 20;

        savePool.AddSaveItem(test.Key, test);
        savePool.AddSaveItem(test2.Key, test2);

        saveJson.Save(savePool.SaveDictionary, Application.persistentDataPath + "/mainConfigFile");
        saveBinary.Save(savePool.SaveDictionary, Application.persistentDataPath + "/mainConfigFile");

        Debug.LogError(loadJson.Load<Test>(test.Key, Application.persistentDataPath + "/mainConfigFile"));
        Debug.LogError(loadBinary.Load<Test>(test2.Key, Application.persistentDataPath + "/mainConfigFile"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
