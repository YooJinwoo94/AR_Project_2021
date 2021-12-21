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
    [Header("다운로드를 원하는 번들 또는 번들들에 포함된 레이블중 아무거나 입력해주세요.")]
    [SerializeField] string LableForBundleDown = string.Empty;

    AsyncOperationHandle handle;




    private void Start()
    {
         Addressables.LoadSceneAsync(assetReference, UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += (handle) =>
          {
              
         };
    }
}
