using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.Threading.Tasks;
using System.Threading;
using System;

public class SaveServiceTest : MonoBehaviour
{
    const string MAIN_CONFIG_FILE_NAME = "mainConfigFile";

    private ISaveService saveService = new SaveService();
    private ISavePool savePool = new SavePool();

    private Test test = new Test();
    private Test test2 = new Test();
    private Test test3 = new Test();
    private Test2 test4 = new Test2();
    string stringTest = "stringTest";
    bool boolTest = true;
    int intTest = 2;
    float floatTest = 3.14f;

    void Start()
    {
        test.Key = "test1";
        test2.Key = "test2";
        test3.Key = "test3";
        test4.Key = "test4";

        test2.hp = 20;
        test3.hp = 30;

        savePool.AddSaveItem(test.Key, test);
        savePool.AddSaveItem(test2.Key, test2);
        savePool.AddSaveItem(test4.Key, test4);

        SaveLoadTest();
    }

    private async Task SaveLoadTest()
    {
        await Save();
        await Load();
    }

    private async Task Save()
    {

        for (int i = 0; i <= (int)ESaveFormat.Binary; i++)
        {
            ESaveFormat eSaveFormat = (ESaveFormat)i;

            await saveService.Save(test3.Key, test3, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            await saveService.Save(savePool.SaveDictionary, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            await saveService.Save(stringTest, stringTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            await saveService.Save("boolTest", boolTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            await saveService.Save("intTest", intTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
            await saveService.Save("floatTest", floatTest, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME);
        }
    }

    private async Task Load()
    {
        for (int i = 0; i <= (int)ESaveFormat.Binary; i++)
        {
            ESaveFormat eSaveFormat = (ESaveFormat)i;

            Debug.LogError("_____________" + eSaveFormat.ToString() + "_____________");

            Debug.LogError(await saveService.Load<Test>(test.Key, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(await saveService.Load<Test>(test2.Key, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(await saveService.Load<Test>(test3.Key, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(await saveService.Load<Test2>(test4.Key, eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(await saveService.Load<string>("stringTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(await saveService.Load<bool>("boolTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(await saveService.Load<int>("intTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
            Debug.LogError(await saveService.Load<float>("floatTest", eSaveFormat, Application.persistentDataPath + "/" + MAIN_CONFIG_FILE_NAME));
        }
    }
}
