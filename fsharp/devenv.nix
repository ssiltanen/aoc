{
  pkgs,
  lib,
  config,
  inputs,
  ...
}:

{
  # https://devenv.sh/packages/
  packages = [
    pkgs.dotnet-sdk_9
    pkgs.fsautocomplete
    pkgs.fantomas
  ];

  languages.dotnet = {
    enable = true;
    package = pkgs.dotnet-sdk_9;
  };
}
