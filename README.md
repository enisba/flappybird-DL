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
### **Training Process**

https://github.com/user-attachments/assets/473ca4fe-6a45-4574-a44e-8b77ce010013



---

## **Technologies Used**
- **Unity 2022.6** (2D Built-in Render Pipeline)
- **ML-Agents 0.28.0**
- **Proximal Policy Optimization (PPO)**
- **Reinforcement Learning**
- **Anaconda / Conda**
```sh
conda create -n flappy_env python=3.8 -y
conda activate flappy_env
pip install mlagents
