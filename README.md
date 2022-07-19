Vitimiti.Sdl2
=============

Marshaled library to use SDL2 in C#.

How to Include
--------------

This library supports the following runtimes:

- win-x64
- win-x86
- osx-arm64
- osx-x64
- linux-x64

To be able to include the library, add the following to your project:

```xml
<ItemGroup>
  <PackageReference Include="Vitimiti.Sdl2" Version="2.0.22-alpha-1" GeneratePathProperty="true" />
</ItemGroup>
```

Then, to be able to use the included native libraries, add the following line:

```xml
<Import Project="$(PkgVitimiti_Sdl2)\targets\RuntimeIdentifiers.targets" />
```

To recap, if you wish to use the included libraries, which you should do, in an example project, you would do:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <DefineTrace>true</DefineTrace>
    <RuntimeIdentifiers>win-x64;win-x86;osx-arm64;osx-x64;linux-x64</RuntimeIdentifiers>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)' == 'Debug'">
    <DefineDebug>true</DefineDebug>
    <DebugType>pdbonly</DebugType>
    <Optimize>false</Optimize>
  </PropertyGroup>

  <PropertyGroup Condition="'$(Configuration)' == 'Release'">
    <DefineDebug>false</DefineDebug>
    <DebugType>none</DebugType>
    <Optimize>true</Optimize>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Vitimiti.Sdl2" Version="2.0.22-alpha-1" GeneratePathProperty="true" />
  </ItemGroup>
    
  <Import Project="$(PkgVitimiti_Sdl2)\targets\RuntimeIdentifiers.targets" />
    
</Project>
```
