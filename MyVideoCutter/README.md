# ✂ My Video Cutter

A simple, clean Windows GUI app to cut video clips using ffmpeg — no subscriptions, no watermarks, no internet required.

---

## 📦 Requirements

| Requirement | Download |
|---|---|
| .NET 8 SDK (to build) | https://dotnet.microsoft.com/download |
| ffmpeg.exe (to run) | https://ffmpeg.org/download.html → Windows builds |

> **Note:** .NET 8 Runtime (not SDK) must be installed on any PC that runs the EXE.
> For a fully self-contained EXE (no runtime needed), see the Advanced Build section below.

---

## 🚀 Quick Start

### Step 1 – Build the EXE
Double-click **`BUILD.bat`** — it will restore packages, build, and publish `MyVideoCutter.exe` into the `publish\` folder.

### Step 2 – Add ffmpeg
Download ffmpeg for Windows from https://ffmpeg.org/download.html  
Extract and copy **`ffmpeg.exe`** into the same folder as `MyVideoCutter.exe`.

```
publish\
  MyVideoCutter.exe   ← your app
  ffmpeg.exe          ← paste here
```

### Step 3 – Run
Double-click `MyVideoCutter.exe` — no installer needed!

---

## 🎬 How to Use

1. Click **Browse…** and select your video file (MP4, MKV, AVI, MOV, etc.)
2. Enter **Start Time** in `hh:mm:ss` format (e.g. `00:01:30`)
3. Enter **End Time** in `hh:mm:ss` format (e.g. `00:03:45`)
4. Click **✂ Cut My Video**
5. The trimmed clip is saved in the **same folder** as your original video

---

## ⚙ Advanced Build — Fully Self-Contained (no .NET needed on target PC)

Run this command instead of BUILD.bat:

```bat
dotnet publish MyVideoCutter\MyVideoCutter.csproj ^
    -c Release ^
    -r win-x64 ^
    --self-contained true ^
    /p:PublishSingleFile=true ^
    /p:EnableCompressionInSingleFile=true ^
    -o .\publish\
```

This bundles the .NET runtime inside the EXE (~60 MB).

---

## 📁 Output Files

Cut videos are saved automatically next to the source file with a name like:

```
MyVideo_cut_00-01-30_to_00-03-45.mp4
```

---

## 🔧 Troubleshooting

| Problem | Solution |
|---|---|
| "ffmpeg.exe not found" | Place ffmpeg.exe next to MyVideoCutter.exe, or add it to your system PATH |
| Cut video is empty or corrupt | Make sure the time range is within the actual video duration |
| App won't start | Install .NET 8 Runtime from https://dotnet.microsoft.com/download |

---

*My Video Cutter uses ffmpeg under the hood — a powerful open-source multimedia framework.*
