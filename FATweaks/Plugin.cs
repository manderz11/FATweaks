using System;
using Exiled.API.Features;
using FATweaks.Handles;

namespace FATweaks
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "FATweaks";
        public override string Author => "manderz11";
        public override Version Version => new Version(1, 0, 0);
        public static Plugin Instance { get; set; }

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            UnregisterEvents();
            base.OnDisabled();
        }

        private Escaping _escapingHandle;
        private Scp096 _scp096Handle;
        private SpawningItem _spawningItemHandle;
        void RegisterEvents()
        {
            _escapingHandle = new Escaping();
            _scp096Handle = new Scp096();
            _spawningItemHandle = new SpawningItem();
            Exiled.Events.Handlers.Player.Escaping += _escapingHandle.OnEscaping;
            Exiled.Events.Handlers.Player.Spawned += _escapingHandle.OnSpawned;
            Exiled.Events.Handlers.Scp096.AddingTarget += _scp096Handle.AddedTarget;
            Exiled.Events.Handlers.Scp096.Enraging += _scp096Handle.Enraging;
            Exiled.Events.Handlers.Map.SpawningItem += _spawningItemHandle.SpawningItemEvent;
            Exiled.Events.Handlers.Player.ItemAdded += _spawningItemHandle.ItemAdded;
        }

        void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Escaping -= _escapingHandle.OnEscaping;
            Exiled.Events.Handlers.Player.Spawned -= _escapingHandle.OnSpawned;
            Exiled.Events.Handlers.Scp096.AddingTarget -= _scp096Handle.AddedTarget;
            Exiled.Events.Handlers.Scp096.Enraging -= _scp096Handle.Enraging;
            Exiled.Events.Handlers.Map.SpawningItem -= _spawningItemHandle.SpawningItemEvent;
            Exiled.Events.Handlers.Player.ItemAdded -= _spawningItemHandle.ItemAdded;
            _escapingHandle = null;
            _scp096Handle = null;
            _spawningItemHandle = null;
        }
    }
}