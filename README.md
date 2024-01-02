# GIO's File Merger

This is a small program I made to for the possibility to break a JavaScript-made
application in multiple parts and merge them all together when ready to debug or
deploy the application.

## Requirements

This was made on a <b>Linux Mint</b> machine, therefore some steps might diverge from your
very own.

- A Linux machine (optional)
- NET Core 7.0
- NET Runtime 7.0

In doubt whether you might already meet the requirements or not, you can open the
terminal and check it directly.

```bash
  dotnet --info
```

## Build and Run

First change the current directory to the root folder of the program and build
the application using Release settings.

```bash
  dotnet build --configuration Release
```

After building the application, two folders will appear inside the directory
one bin/ and the other, obj/.

Inside <b>bin/Release/net7.0/</b> will be a file named <b>FileMerger.dll</b>.
Move to to directory and run the and run the built program.

```bash
  dotnet FileMerger.dll
```
