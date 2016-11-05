﻿using Rocket.API;
using System.Xml.Serialization;
using Rocket.Unturned.Items;
using System.Collections.Generic;
using System;

namespace Rocket.Unturned.Serialisation
{
    public sealed class AutomaticSaveSettings
    {
        [XmlAttribute]
        public bool Enabled = true;

        [XmlAttribute]
        public int Interval = 1800;
    }

    public sealed class RocketModObservatorySettings
    {
        [XmlAttribute]
        public bool CommunityBans = true;

        [XmlAttribute]
        public bool KickLimitedAccounts = true;

        [XmlAttribute]
        public bool KickTooYoungAccounts = true;

        [XmlAttribute]
        public long MinimumAge = 604800;
    }

    public class UnturnedSettings : IDefaultable
    {
        [XmlElement("RocketModObservatory")]
        public RocketModObservatorySettings RocketModObservatory = new RocketModObservatorySettings();

        [XmlElement("AutomaticSave")]
        public AutomaticSaveSettings AutomaticSave = new AutomaticSaveSettings();

        [XmlElement("CharacterNameValidation")]
        public bool CharacterNameValidation = false;

        [XmlElement("CharacterNameValidationRule")]
        public string CharacterNameValidationRule = @"([\x00-\xAA]|[\w_\ \.\+\-])+";

        public bool LogSuspiciousPlayerMovement = true;

        [XmlArrayItem(ElementName = "Item")]
        public List<Blacklisting> Items;

        public bool ItemBlacklisting;

        public bool ItemSpawnLimiting;

        public int MaxSpawnAmount;

    public void LoadDefaults()
        {
            AutomaticSave = new AutomaticSaveSettings();
            RocketModObservatory = new RocketModObservatorySettings();
            CharacterNameValidation = true;
            CharacterNameValidationRule = @"([\x00-\xAA]|[\w_\ \.\+\-])+";
            LogSuspiciousPlayerMovement = true;
            ItemBlacklisting = false;
            ItemSpawnLimiting = false;
            MaxSpawnAmount = 10;
            Items = new List<Blacklisting>()
            {
                new Items.Blacklisting(518)
            };
        }
    }
}