# AdSqlProject error in dotnet sdk 9 sample project

When using AddSqlProject in a .NET SDK 9 / .NET Aspire environment, building a csproj called from Aspire fails

## error pattern

.NET SDK 9 and run AddSqlProject

```
dotnet new global.json --sdk-version 9.0.0 --roll-forward latestMinor --force
dotnet user-secrets -p .\AppHost\ remove "database_project_enable"
dotnet run --project .\AppHost\
```

→ webapp is build error

### webapp console log (1)

```
__________________________________________________
プロジェクト "C:\Users\XXXXXX\WebApp\WebApp.csproj" (ComputeRunArguments ターゲット):
 
C:\Users\XXXXXX\WebApp\WebApp.csproj : error MSB4057: ターゲット "ComputeRunArguments" はプロジェクト内に存在しません。
プロジェクト "WebApp.csproj" のビルドが終了しました -- 失敗。
 このプロジェクトで実行コマンドを検出するための ComputeRunArguments ターゲットの実行に失敗しました。エラーと警告を修正して、もう一度実行してください。
```

## no error pattern 1

.NET SDK 9 and not run AddSqlProject

```
dotnet new global.json --sdk-version 9.0.0 --roll-forward latestMinor --force
dotnet user-secrets -p .\AppHost\ set "database_project_enable" false
dotnet run --project .\AppHost\
```

→ webapp is running

### webapp console log (2)

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:53604
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:53605
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\XXXXXX\WebApp
```

## no error pattern 2

.NET SDK 8 and enable AddSqlProject

```
dotnet new global.json --sdk-version 8.0.0 --roll-forward latestMinor --force
dotnet user-secrets -p .\AppHost\ remove "database_project_enable"
dotnet run --project .\AppHost\
```

→ webapp is running

### webapp console log (3)

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:53911
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:53912
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\XXXXXX\WebApp
```

## no error pattern 3

apphost project targetFramework net8.0 → net9.0 and .NET SDK 9 and run AddSqlProject

### webapp console log (4)

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:56914
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:56915
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\XXXXXX\WebApp
```

## details (running / not running)

| AppHost project TargetFramework | AppHost project use AddSqlProject | .NET SDK (dotnet --version) | WebApp project is running |
| ------------------- | -------------------- | ---------- | ----------------------------- |
| net8.0                   | use                        | 8.0.410 | running |
| net8.0                   | use                       | 9.0.300 | not running |
| net8.0                   | not use                | 9.0.300 | running |
| net9.0                   | use                       | 9.0.300 | running |
| net8.0                   | use                       | 10.0.100-preview.4.25258.110 | not running |
| net9.0                   | use                       | 10.0.100-preview.4.25258.110 | running |
| net10.0                   | use                       | 10.0.100-preview.4.25258.110 | running |
