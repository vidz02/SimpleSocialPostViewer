# Simple Social Post Viewer

A Unity project that simulates a social media post feed, built for the Unity Assignment.  
This project demonstrates Unity UI, C# scripting, data-driven UI, persistent state, and interactive features.

---

## 🚀 Project Overview

This project recreates a social media-style post viewer using Unity’s UI system.  
It displays user posts loaded from JSON, allows liking/unliking with persistent state, supports comments, and features smooth UI animations.

---

## 🎯 Features

### Core Features
- **Social Media Post Card**
  - User Name (Text)
  - Profile Picture (Placeholder Image)
  - Post Content (Dummy Text)
  - Like Button (toggles liked/unliked)
- **Basic Logic**
  - Like button changes appearance (color) when toggled
  - Like count increases/decreases interactively
- **Data-Driven**
  - Posts loaded from a local JSON file

### Bonus Features (Assignment Optional Points)
- **Multiple Posts:**  
  Scrollable vertical list of posts using Unity’s Scroll View.
- **Comment Button & Popup:**  
  Each post has a comment button that opens a popup panel with dummy comments.
- **Dynamic JSON Loading:**  
  All post data is loaded dynamically from a local JSON file.
- **Persistent Like State:**  
  Like status is saved using PlayerPrefs and persists across sessions.
- **UI Animations:**  
  Smooth fade-in for panels and animated button click effects for enhanced user experience.

---

## 🛠️ Tools & Technologies

- Unity 2022.3 LTS
- Unity UI Components (Canvas, Image, TextMeshPro, Button, Scroll View)
- C# scripting
- No third-party plugins

---

## 💡 What I Learned

- **Unity UI System:**  
  Gained practical experience with Canvas, Scroll View, Layout Groups, and prefab-based UI design.
- **C# Scripting for UI:**  
  Connected UI elements to scripts, dynamically loaded and displayed data, and handled user interactions.
- **State Persistence:**  
  Used PlayerPrefs to save UI state (liked/unliked) across play sessions.
- **UI Animation:**  
  Implemented smooth fade-ins and button click animations for a polished user experience.
- **Project Organization:**  
  Structured the project for clarity and easy extensibility.

---

## 🖼️ Screenshots
![Main UI](Demo_Media/Screenshot_1.png)
![Comments Popup](Demo_Media/Screenshot_2.png)

## Demo Video
![Watch the demo](Demo_Media/Demo_Video.gif)

---

## 📦 How to Run

1. **Clone or Download** this repository.
2. **Open** the project in Unity 2022.3 LTS (or higher).
3. **Open** the `MainScene` and press **Play** to interact with the post viewer.

---

## ✅ Assignment Coverage Checklist

| Requirement                                   | Implemented? |
|-----------------------------------------------|:------------:|
| Unity UI system (Canvas)                      |      ✔️      |
| User Name (Text)                              |      ✔️      |
| Profile Picture (Image)                       |      ✔️      |
| Post Content (Text)                           |      ✔️      |
| Like Button (toggle)                          |      ✔️      |
| Like Button visual change                     |      ✔️      |
| Like Count                                    |      ✔️      |
| Data loaded from JSON                         |      ✔️      |
| Multiple posts (Scroll View)                  |      ✔️      |
| Comment button & popup panel                  |      ✔️      |
| Persistent like state (PlayerPrefs)           |      ✔️      |
| UI animations (fade, button click)            |      ✔️      |

---

## 📝 Notes
The project that started with simple and core requirements.
Now also has bonus features such as, multiple posts, comments, persistent likes & animations.

---
##
Thank you for reviewing my project!
