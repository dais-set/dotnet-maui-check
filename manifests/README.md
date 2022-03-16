  # Manifest Files
  
  These are used by the tool to parse up to date versions and information on which things to validate and install.
  
  They are grouped into the following channels:
  
  
  ### Default
  Embedded resource, to align with the current MAUI stable version available:
  - maui.manifest.json
  - https://aka.ms/dotnet-maui-check-manifest
  
  ### Preview
  Embedded resource, to align with MAUI preview 13 version available:
  - maui-preview.manifest.json
  - https://aka.ms/dotnet-maui-check-manifest-preview (currently it's old, preview 12)
  - https://raw.githubusercontent.com/dotnet/maui/release/6.0.2xx-preview13/eng/Versions.props
  
  ### Main
  Embedded resource, to align with the current MAUI main branch version available and will change often:
  - maui-main.manifest.json
  - https://aka.ms/dotnet-maui-check-manifest-main
