using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using UnityEngine.UI;

public class AddressableMangera : MonoBehaviour
{
    [SerializeField] AssetReference assetReference;


    [Space]
    [Header("�ٿ�ε带 ���ϴ� ���� �Ǵ� ����鿡 ���Ե� ���̺��� �ƹ��ų� �Է����ּ���.")]
    [SerializeField] string LableForBundleDown = string.Empty;

    AsyncOperationHandle handle;




    private void Start()
    {
         Addressables.LoadSceneAsync(assetReference, UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += (handle) =>
          {
              
         };
    }
}
