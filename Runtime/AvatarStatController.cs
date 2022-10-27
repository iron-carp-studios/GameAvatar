using IronCarpStudios.Unity.GameAvatar;
using System.Collections.Generic;
using UnityEngine;

namespace IronCarpStudios.Unity.Avatar
{
    [RequireComponent(typeof(GameAvatar))]
    public class AvatarStatController : MonoBehaviour
    {
        [SerializeField]
        private StringFloatSerializableDictionary _statCollection = new StringFloatSerializableDictionary();

        [SerializeField]
        private StringFloatSerializableDictionary _statModifiers = new StringFloatSerializableDictionary();

        public void SetStats(StringFloatSerializableDictionary statCollection)
        {
            _statCollection = statCollection;
        }

        //public float this[string key] => GetStatValue(key);

        public float GetStatValue(string key)
        {
            if (_statCollection.TryGetValue(key, out var value))
            {
                return value;
            }

            return 0;
        }

        public Dictionary<string, float> ListStats()
        {
            return new Dictionary<string, float>(_statCollection);
        }

        public bool SetStatValue(string key, float value)
        {
            if (_statCollection.ContainsKey(key))
            {
                _statCollection[key] = value;
                return true;
            }

            return false;
        }

        public float GetModifierValue(string key)
        {
            if (_statModifiers.TryGetValue(key, out var value))
            {
                return value;
            }

            return 0;
        }

        public void AddModifier(string modifierKey, float modifierValue)
        {
            if (_statModifiers.ContainsKey(modifierKey))
            {
                _statModifiers[modifierKey] += modifierValue;
            }
            else
            {
                _statModifiers.Add(modifierKey, modifierValue);
            }
        }
    }

    [SerializeField]
    public class AvatarStatDataModel
    {
        public int Attack;
        public int Defense;
        public int Accuracy;
        public int Evasion;
    }

    public class StatModifier
    {
        public string Type;
        public float Value;
    }
}