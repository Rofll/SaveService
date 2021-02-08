using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

public class SaveServiceTest : MonoBehaviour
{
    const string MAIN_CONFIG_FILE_NAME = "mainConfigFile";

    private ISaveService saveService = new SaveService();
    private ISavePool savePool = new SavePool();

    private Test test = new Test();
    private Test test2 = new Test();
    private Test test3 = new Test();

    void Start()
    {
        string stringTest = "stringTest";
        bool boolTest = true;
        int intTest = 2;
        float floatTest = 3.14f;

        test.Key = "test1";
        test2.Key = "test2";
        test3.Key = "test3";

        test2.hp = 20;
        test3.hp = 30;

        savePool.AddSaveItem(test.Key, test);
        savePool.AddSaveItem(test2.Key, test2);

        //Debug.LogError("_____________PlayerPrefs_____________");
        //saveService.Save(test3.Key, test3, ESaveFormat.PlayerPrefs);
        //saveService.Save(savePool.SaveDictionary, ESaveFormat.PlayerPrefs);
        //saveService.Save(stringTest, stringTest, ESaveFormat.PlayerPrefs);
        //saveService.Save("boolTest", boolTest, ESaveFormat.PlayerPrefs);
        //saveService.Save("intTest", intTest, ESaveFormat.PlayerPrefs);
        //saveService.Save("floatTest", floatTest, ESaveFormat.PlayerPrefs);

        //Debug.LogError(saveService.Load<Test>(test.Key, ESaveFormat.PlayerPrefs));
        //Debug.LogError(saveService.Load<Test>(test2.Key, ESaveFormat.PlayerPrefs));
        //Debug.LogError(saveService.Load<Test>(test3.Key, ESaveFormat.PlayerPrefs));
        //Debug.LogError(saveService.Load<string>("stringTest", ESaveFormat.PlayerPrefs));
        //Debug.LogError(saveService.Load<bool>("boolTest", ESaveFormat.PlayerPrefs));
        //Debug.LogError(saveService.Load<int>("intTest", ESaveFormat.PlayerPrefs));
        //Debug.LogError(saveService.Load<float>("floatTest", ESaveFormat.PlayerPrefs));

        for (int i = 0; i <= (int)ESaveFormat.ProtoBuf; i++)
        {
            ESaveFormat eSaveFormat = (ESaveFormat)i;

            Debug.LogError("_____________" + eSaveFormat.ToString() + "_____________");

            saveService.Save(test3.Key, test3, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            saveService.Save(savePool.SaveDictionary, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            saveService.Save(stringTest, stringTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            saveService.Save("boolTest", boolTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            saveService.Save("intTest", intTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            saveService.Save("floatTest", floatTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);

            Debug.LogError(saveService.Load<Test>(test.Key, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(saveService.Load<Test>(test2.Key, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(saveService.Load<Test>(test3.Key, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(saveService.Load<string>("stringTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(saveService.Load<bool>("boolTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(saveService.Load<int>("intTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(saveService.Load<float>("floatTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
        }
    }
}
