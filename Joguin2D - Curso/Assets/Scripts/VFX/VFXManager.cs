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
                    Destroy(item.gameObject, 3f);
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
