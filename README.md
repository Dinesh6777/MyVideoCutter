# MyVideoCutter
A lightweight Windows desktop app to trim videos instantly — no re-encoding, no quality loss. It's an offline video cutter with no limits and watermark.

<div align="center">


# ✂ My Video Cutter

**A lightweight Windows desktop app to trim videos instantly — no re-encoding, no quality loss.**

![Platform](https://img.shields.io/badge/platform-Windows%2010%2F11-blue?style=flat-square)
![Language](https://img.shields.io/badge/language-C%23%20.NET%2010-purple?style=flat-square)
![FFmpeg](https://img.shields.io/badge/powered%20by-FFmpeg-green?style=flat-square)
![License](https://img.shields.io/badge/license-MIT-orange?style=flat-square)

</div>

---
## 🖼 Screenshot
<img width="607" height="474" alt="image" src="https://github.com/user-attachments/assets/9cece7de-1dd4-4bdf-95fe-45eacdbc4d0c" />

## [Download -Click here](https://raw.githubusercontent.com/Dinesh6777/MyVideoCutter/refs/heads/main/Download/MyVideoCutter.exe)


## 📖 Overview

**My Video Cutter** is a clean, dark-themed WinForms desktop application that lets you trim any video file by specifying a start and end time. It uses **FFmpeg** under the hood with stream copy mode (`-c copy`), meaning cuts are near-instant and completely lossless — no re-encoding, no waiting, no quality degradation.

---

## ✨ Features

- 📂 **Browse & Select** — File picker with support for all major video formats
- ⏱ **Precise Trimming** — Set start and end times in `hh:mm:ss` format
- ⚡ **Instant Cuts** — Uses FFmpeg stream copy, so trimming is fast regardless of file size
- 🎯 **Lossless Output** — No re-encoding means zero quality loss
- 💾 **Smart Output Naming** — Output file is saved next to the original with a timestamped name (e.g. `video_cut_00-01-30_to_00-03-45.mp4`)
- 🖥 **Portable EXE** — Single `.exe` file, self-contained, no installation required
- 🌙 **Dark UI** — Easy on the eyes, modern dark theme
- 🔍 **Auto FFmpeg Detection** — Automatically finds `ffmpeg.exe` from the app folder, `C:\ffmpeg\bin\`, or system PATH

---



---

## 🛠 Requirements

| Requirement | Details |
|---|---|
| **OS** | Windows 10 / 11 (64-bit) |
| **FFmpeg** | `ffmpeg.exe` must be available (see setup below) |
| **.NET Runtime** | Bundled — no installation needed on target PC |

---

## 🚀 Getting Started

### 1. Download FFmpeg

Download FFmpeg from [https://ffmpeg.org/download.html](https://ffmpeg.org/download.html)

Recommended Windows build: **gyan.dev** or **BtbN** release builds.

Place `ffmpeg.exe` in **one** of these locations (the app checks all three automatically):

```
Option A)  Same folder as MyVideoCutter.exe        ← recommended
Option B)  C:\ffmpeg\bin\ffmpeg.exe
Option C)  Anywhere on your system PATH
```

### 2. Run the App

Just double-click `MyVideoCutter.exe` — no installation needed.

---

## 📋 How to Use

1. Click **📂 Browse** and select your video file
2. Enter the **Start Time** in `hh:mm:ss` format (e.g. `00:01:30`)
3. Enter the **End Time** in `hh:mm:ss` format (e.g. `00:03:45`)
4. Click **✂ Cut My Video**
5. The trimmed file is saved next to the original automatically

**Example output filename:**
```
original.mp4  →  original_cut_00-01-30_to_00-03-45.mp4
```

---

## 🔧 Building from Source

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Windows 10 / 11

### Clone & Build

```bash
git clone https://github.com/yourusername/MyVideoCutter.git
cd MyVideoCutter/MyVideoCutter
dotnet build
```

### Run

```bash
dotnet run
```

### Publish as Portable EXE

```bash
dotnet publish -c Release
```

Output will be at:
```
bin\Release\net10.0-windows\win-x64\publish\MyVideoCutter.exe
```

---

## 📁 Project Structure

```
MyVideoCutter/
├── README.md
└── MyVideoCutter/
    ├── MyVideoCutter.csproj     # Project config & publish settings
    ├── Program.cs               # App entry point
    ├── MainForm.cs              # UI + all application logic
    └── app.ico                  # Application icon
```

---

## ⚙ How It Works

My Video Cutter calls FFmpeg with the following command internally:

```bash
ffmpeg -y -ss <start> -i "input.mp4" -to <duration> -c copy "output.mp4"
```

| Flag | Purpose |
|---|---|
| `-ss <start>` | Seek to start time (placed before `-i` for fast keyframe seek) |
| `-to <duration>` | Cut duration from start |
| `-c copy` | Stream copy — no re-encoding, instant and lossless |
| `-y` | Overwrite output if it exists |

---

## 🎞 Supported Formats

| Format | Extension |
|---|---|
| MP4 | `.mp4` |
| Matroska | `.mkv` |
| AVI | `.avi` |
| QuickTime | `.mov` |
| Windows Media | `.wmv` |
| Flash Video | `.flv` |
| WebM | `.webm` |
| MPEG Transport Stream | `.ts` |

Any format supported by FFmpeg will also work via the **All Files** filter in the browser.

---

## ❓ Troubleshooting

| Problem | Solution |
|---|---|
| App won't open | Run from `cmd.exe` to see the error message |
| "ffmpeg.exe not found" | Place `ffmpeg.exe` next to `MyVideoCutter.exe` |
| Cut starts slightly off | Normal with `-c copy`; FFmpeg snaps to nearest keyframe |
| Output file is 0 bytes | Check that start time is earlier than end time |
| Antivirus blocks the app | This is common with self-contained .NET exes; whitelist it |

---

## 📄 License

This project is licensed under the MIT License.

---

## 🙏 Acknowledgements

- [FFmpeg](https://ffmpeg.org/) — the powerful multimedia framework that does the actual cutting
- [Microsoft .NET](https://dotnet.microsoft.com/) — WinForms application framework

---
| **Feature**                | **Description**                                                                                                                                               | **Benefit**                                                      |
|----------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------|
| **Offline Video Cutter**    | This offline app allows you to cut video files without needing an internet connection.                                                                        | No need for an internet connection; works seamlessly offline.   |
| **Crop Video**              | Cropping allows you to frame the video to the desired area or change the frame proportions.                                                                    | Easily focus on the important parts of the video.                |
            |
| **Any Format Supported**    | The app supports almost every video format. If your file fails to open, it may be damaged or too large.                                                         | Supports a wide range of video formats for flexibility.          |
| **Easy Video Trimming**     | After selecting your file, add your trim points and cut your video with no complicated controls. Everything is just a few clicks away.                     | Simple and intuitive trimming with minimal steps.                |
| **Security Guaranteed**     | Your files are on your device, ensuring privacy and security.                                        | Peace of mind knowing your files are safe and private.           |
| **Offline Video Editing**   | The app allows video cutting and editing directly on your device, with no need for an internet connection. Any file size is supported, no limits                  | Full control over your video editing without relying on the internet. |

<div align="center">

Made with ❤ using C# and FFmpeg

</div>

| SEO Keyword Tags                |
|----------------------------------|
| MyVideoCutter                    |
| Video Cutter                     |
| MKV Cutter                       |
| MOV Cutter                       |
| WEBM Cutter                      |
| WMV Cutter                       |
| MPEG Cutter                      |
| ASF Cutter                       |
| Android Video Cutter             |
| Offline Video Cutter             |
| Lossless Video Cutter            |
| TikTok Video Cutter              |
| Instagram Video Cutter           |
| X (ex-Twitter) Video Trimmer     |
| Video Editing Tool               |
| Free Video Cutter                |
| Video Trimming Software          |
| Cut Video Files                  |
| Trim Video Offline               |
| Video Cutter for Android         |
| Video Trimmer for Social Media   |
| Video Cutter for TikTok          |
| Instagram Video Trimming         |
| Lossless Video Editing           |
| MKV Video Cutter                 |
| MOV Trimming Tool                |
| MP4 Cutter                       |
