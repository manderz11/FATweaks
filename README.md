# FATweaks

F~~ucking~~ Awesome Tweaks

A Exiled plugin for SCP:SL. This plugin contains many bundled small tweaks intended for heavily modded servers.

## Installation

-Download a release in the [release](https://github.com/manderz11/FATweaks/releases) tab.

-Place the plugin .dll file inside EXILED/Plugins

-Start the server

-Profit

## Features

- Keep effects on escape
- Jailbird charge ammount changing
- (untested) SCP096 target spotted rage time increase
- (untested) increase base SCP096 max rage time

Want to suggest more features? Create a issue with the suggestion tag in [issues](https://github.com/manderz11/FATweaks/issues)

## TO-DO (upcoming features)

- none planned yet, suggest more features!

## Configuring

Inside EXILED/Configs edit your servers (port)-config.yml

Under f_a_tweaks edit the configurations to your desires

Example configuration:
```
f_a_tweaks:
  is_enabled: true
  # Should effects be kept when escaping
  keep_escape_effects: true
  # Blacklisted kept effects when escaping
  blacklisted_escape_effects:
  - Invisible
  - Blinded
  - Corroding
  - CardiacArrest
  - Traumatized
  - Stained
  - Flashed
  - Scanned
  - Deafened
  - Concussed
  # Increase 096 rage time for every person that spots 096
  spotted096_rage_time_increase: 0
  # Increase max 096 rage time by
  increased_max096_rage_time: 0
  # Change max jailbird charge by ammount
  jailbird_max_charge_ammount_change: -3
  debug: false
```

## Support

Support for the plugin can only be found on the [issues](https://github.com/manderz11/FATweaks/issues) tab or by messaging me on discord (@manderz11)
