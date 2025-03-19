# Flappy Bird AI - Training with Unity ML-Agents

This project aims to train an AI agent to play **Flappy Bird** using **Unity ML-Agents**.  
The AI learns **optimal gameplay strategies** through **Reinforcement Learning (RL)**, using the **Proximal Policy Optimization (PPO)** algorithm.

---

## **Project Overview**

- Developed **Flappy Bird mechanics** in Unity 2D.
- Trained an AI agent using **ML-Agents**.
- Implemented **an automatic training loop** to select the best agent.
- Added **UI elements** to display scores and the best-performing agent.
- Used **TensorBoard** to track the AI’s learning process.

---

## **Project Screenshots**
### **Gameplay**
<img src="assets/gameplay.png" width="600">

### **Training Process**
<img src="assets/training_process.gif" width="600">

---

## **🛠 Technologies Used**
- **Unity 2022.x** (2D Built-in Render Pipeline)
- **ML-Agents 0.28.0**
- **Python 3.8**
- **Proximal Policy Optimization (PPO)**
- **Reinforcement Learning**
- **Anaconda / Conda**

---

## **Installation & Setup**

### **1️ Required Software**
Before running the project, make sure you have the following installed:
- **Unity 2022.x or later**
- **Python 3.8+**
- **Anaconda** or **Miniconda**
- **ML-Agents 0.28.0**

### ML-Agents Installation
Create a **Conda virtual environment** and install the required packages:

```sh
conda create -n flappy_env python=3.8 -y
conda activate flappy_env
pip install mlagents
