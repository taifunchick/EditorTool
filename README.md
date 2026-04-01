# 🛠 Unity Editor Tool: Road Builder

> One-click tool to place trees along a road. Saves time for level designers. Video demonstration in the Media folder.

[![Unity](https://img.shields.io/badge/Unity-2021.3+-000.svg?logo=unity)](https://unity.com)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

---

## 🎯 What it does

Right-click the component in Inspector → **"🌲 Place Trees"** → 50 trees appear along your road path. Includes **Undo support** (Ctrl+Z).

---

## ⚙️ Requirements

- Unity 2021.3 LTS or newer
- No external packages required

---

## 🚀 Quick Start

1. Copy folders to your project.
2. Create road: Place empty GameObjects as path points.
3. Add component `Road Builder Component` to any object.
4. Assign **Tree Prefab** and **Road Points** in Inspector.
5. Click **"🌲 Place Trees"** button.

---

## 🔑 Key Features

| Feature | Description |
|---------|-------------|
| **ContextMenu** | Button appears in Inspector (no extra window) |
| **Undo Support** | Full Ctrl+Z support via `Undo.RegisterCreatedObjectUndo` |
| **Editor Folder** | Editor code isolated in `/Editor` (excluded from builds) |
| **Custom Inspector** | Clean UI with `CustomEditor` attribute |

---

## 📄 License

MIT — free for learning and portfolio use.
