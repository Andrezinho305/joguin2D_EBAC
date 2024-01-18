using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

    public class VFXManager : Singleton<VFXManager>
    {
        public enum VFXType
        {
            JUMP,
            RUN,
            AMBIENT,
            COINS
        }

        public List<VFXManagerSettup> vfxSettup;

        public void PlayVFXbyType(VFXType vfxType, Vector3 position)
        {
            foreach (var i in vfxSettup)
            {
                if (i.vfxType == vfxType)
                {
                    var item = Instantiate(i.prefab);
                    item.transform.position = position;
                    Destroy(item.gameObject, 5f); //destroi o objeto que é criado - memoria e console, nao viual
                    break;
                }
            }

        }

    }

    [System.Serializable]
    public class VFXManagerSettup
    {
        public VFXManager.VFXType vfxType;
        public GameObject prefab;
    }
