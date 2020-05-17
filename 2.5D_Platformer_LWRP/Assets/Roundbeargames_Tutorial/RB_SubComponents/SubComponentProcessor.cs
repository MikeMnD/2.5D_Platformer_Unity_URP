﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class SubComponentProcessor : MonoBehaviour
    {
        public Dictionary<SubComponentType, SubComponent> ComponentsDic = new Dictionary<SubComponentType, SubComponent>();
        public CharacterControl control;

        [Space(15)] public BlockingObjData blockingData;
        [Space(15)] public LedgeGrabData ledgeGrabData;
        [Space(15)] public RagdollData ragdollData;
        [Space(15)] public ManualInputData manualInputData;
        [Space(15)] public BoxColliderData boxColliderData;

        private void Awake()
        {
            control = GetComponentInParent<CharacterControl>();
        }

        public void FixedUpdateSubComponents()
        {
            FixedUpdateSubComponent(SubComponentType.LEDGECHECKER);
            FixedUpdateSubComponent(SubComponentType.RAGDOLL);
            FixedUpdateSubComponent(SubComponentType.BLOCKINGOBJECTS);
            FixedUpdateSubComponent(SubComponentType.BOX_COLLIDER_UPDATER);
        }

        public void UpdateSubComponents()
        {
            UpdateSubComponent(SubComponentType.MANUALINPUT);
        }

        void UpdateSubComponent(SubComponentType type)
        {
            if (ComponentsDic.ContainsKey(type))
            {
                ComponentsDic[type].OnUpdate();
            }
        }

        void FixedUpdateSubComponent(SubComponentType type)
        {
            if (ComponentsDic.ContainsKey(type))
            {
                ComponentsDic[type].OnFixedUpdate();
            }
        }
    }
}
