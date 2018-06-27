using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets
{
    public class PlayerData
    {

        private DateTime time;          // Timestamp when the user last smoked.
        private int cigarettes;         // Amount of cigarettes the user smoked per day.
        private double price;           // Price of a cigarrete.
        private double balance;         // Currency of the player.
        private double experience, experienceNeeded;      // Experience of the player.
        private int maruJumpHighScore, snakeHighscore, bbtanHighscore, level;
        private List<Achievement> achievement;
        private List<List<ShopItem>> shopInventory;
        private float[] paddleColor = new float[4], appleColor = new float[4], snakeColor = new float[4], bbtanBallColor = new float[4];

        public DateTime Time {
            get {
                return time;
            }

            set {
                time = value;
            }
        }

        public int Cigarettes {
            get {
                return cigarettes;
            }

            set {
                cigarettes = value;
            }
        }

        public double Price {
            get {
                return price;
            }

            set {
                price = value;
            }
        }

        public double Balance {
            get {
                return balance;
            }

            set {
                balance = value;
            }
        }

        public double Experience {
            get {
                return experience;
            }

            set {
                experience = value;
            }
        }

        public int MaruJumpHighScore
        {
            get
            {
                return maruJumpHighScore;
            }

            set
            {
                maruJumpHighScore = value;
            }
        }

        public int SnakeHighscore
        {
            get
            {
                return snakeHighscore;
            }

            set
            {
                snakeHighscore = value;
            }
        }
        public int BBtanHighscore
        {
            get
            {
                return bbtanHighscore;
            }

            set
            {
                bbtanHighscore = value;
            }
        }

        public List<Achievement> Achievements
        {
            get
            {
                return achievement;
            }

            set
            {
                achievement = value;
            }
        }

        public List<List<ShopItem>> ShopInventory
        {
            get
            {
                return shopInventory;
            }

            set
            {
                shopInventory = value;
            }
        }

        public Color BBtanBallColor
        {
            get
            {
                return new Color(bbtanBallColor[0], bbtanBallColor[1], bbtanBallColor[2], bbtanBallColor[3]);
            }
            set
            {
                bbtanBallColor[0] = value.r;
                bbtanBallColor[1] = value.g;
                bbtanBallColor[2] = value.b;
                bbtanBallColor[3] = value.a;
            }
        }
        public Color PaddleColor
        {
            get
            {
                return new Color(paddleColor[0], paddleColor[1], paddleColor[2], paddleColor[3]);
            }
            set
            {
                paddleColor[0] = value.r;
                paddleColor[1] = value.g;
                paddleColor[2] = value.b;
                paddleColor[3] = value.a;
            }
        }
        public Color SnakeColor
        {
            get
            {
                return new Color(snakeColor[0], snakeColor[1], snakeColor[2], snakeColor[3]);
            }
            set
            {
                snakeColor[0] = value.r;
                snakeColor[1] = value.g;
                snakeColor[2] = value.b;
                snakeColor[3] = value.a;
            }
        }
        public Color AppleColor
        {
            get
            {
                return new Color(appleColor[0], appleColor[1], appleColor[2], appleColor[3]);
            }
            set
            {
                appleColor[0] = value.r;
                appleColor[1] = value.g;
                appleColor[2] = value.b;
                appleColor[3] = value.a;
            }
        }

        public double ExperienceNeeded
        {
            get
            {
                return experienceNeeded;
            }

            set
            {
                experienceNeeded = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public bool saveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

            serializablePlayerData data = new serializablePlayerData();
            data.time       = this.Time;
            data.cigarettes = this.Cigarettes;
            data.price      = this.Price;
            data.balance    = this.Balance;
            data.experience = this.Experience;
            data.experienceneeded = this.experienceNeeded;
            data.level = this.level;
            data.maruJumpHighScore = this.maruJumpHighScore;
            data.snakeHighscore = this.SnakeHighscore;
            data.bbtanHighscore = this.bbtanHighscore;
            data.appleColor = this.appleColor;
            data.BBtanBallColor = this.bbtanBallColor;
            data.paddleColor = this.paddleColor;
            data.snakeColor = this.snakeColor;
            
            data.achievements = this.achievement;
            data.inventory = this.shopInventory;

            bf.Serialize(file, data);
            file.Close();
			return true;
        }

        public bool loadData()
        {
            if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

                serializablePlayerData data = bf.Deserialize(file) as serializablePlayerData;
                file.Close();

                this.time       = data.time;
                this.cigarettes = data.cigarettes;
                this.price      = data.price;
                this.balance    = data.balance;
                this.experience = data.experience;
                this.experienceNeeded = data.experienceneeded;
                this.level = data.level;
                if(data.snakeColor != null)
                this.snakeColor = data.snakeColor;
                if(data.BBtanBallColor != null)
                this.bbtanBallColor = data.BBtanBallColor;
                if(data.paddleColor != null)
                this.paddleColor = data.paddleColor;
                if (data.appleColor != null)
                this.appleColor = data.appleColor;
                this.MaruJumpHighScore = data.maruJumpHighScore;
                this.SnakeHighscore = data.snakeHighscore;
                this.achievement = data.achievements;
                this.shopInventory = data.inventory;
                this.bbtanHighscore = data.bbtanHighscore;
				return true;
            }
			return false;
        }
    }
}
[Serializable]
public class serializablePlayerData {
    public DateTime time;
    public int cigarettes;
    public double price;
    public double balance;
    public double experience;
    public int level;
    public double experienceneeded;
    public int maruJumpHighScore, snakeHighscore, bbtanHighscore;
    public float[] paddleColor, snakeColor, appleColor, BBtanBallColor;
    public List<Achievement> achievements;
    public List<List<ShopItem>> inventory;
}
