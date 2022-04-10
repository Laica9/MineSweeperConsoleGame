using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweep
{
    public class Board
    {
        private GameState state; // game running, game over or win
        private Tile[] tileMap; // array of tile objects
        private int number_of_mines, rows, columns;
        private string newL = Environment.NewLine;

        public Board() {}

        // Display -------------------------------------------------------
        public void Display() {
            StringBuilder s = new StringBuilder();

            for(int i=0;i<this.rows;i++) {
                for(int j=0;j<this.columns;j++) {
                    Tile tile = this.tileMap[j+i*this.columns];
                    s.Append(tile.DrawTile());
                }
                s.Append(newL);
            }
            Console.WriteLine(s.ToString());
        }
        // Methods -------------------------------------------------------
        /// <summary>
        /// Method that initiates making of new tile array objects.
        /// It then invokes other methods to make empty map array (of tiles),
        /// as well as invokes method to place mines in the map.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="number_of_mines"></param>
        public void newTileMap(int rows, int columns, int number_of_mines) {
            this.state = GameState.GAMEON;
            this.rows = rows;
            this.columns = columns;
            this.number_of_mines = number_of_mines;
            this.tileMap = MakeEmptyTileMap(rows, columns);
            InsertMines(this.tileMap, number_of_mines); //update tile with mines
        }

        public bool GameOver() {return this.state == GameState.GAME_LOST;}
        public bool Win() {return this.state == GameState.GAME_WON;}
        
        /// <summary>
        /// Method that iterates through tile objects and making array. 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns>tile array</returns>
        private Tile[] MakeEmptyTileMap(int rows, int columns) {
            Tile[] tile = new Tile[rows*columns];
            for(int row=0;row<this.rows;row++) {
                for(int col=0;col<this.columns;col++) {
                    tile[col + row * this.columns] = new Tile();
                }
            }
            return tile;
        }

        /// <summary>
        /// Method that randomly generates mines and sets it in a map array.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="number_of_mines"></param>
        private void InsertMines(Tile[] map, int number_of_mines) {
            int size = map.Length;
            Random rnd = new Random();

            int mines = 0;
            while (mines < number_of_mines) {
                int position = rnd.Next(size);
                if(map[position].IsMine() == false) {
                    map[position].SetMine();
                    mines++;
                    IncrementNearMines(map,position);
                }
            }
        }

        private void IncrementNearMines(Tile[] tileMap, int position) {
            // if position is first column 
            int col = position % this.columns; //index
            bool firstCol = col == 0;
            bool lastCol = col == this.columns-1;

            // rows
            int row = position / this.columns;
            bool firstRow = row == 0;
            bool isLastRow = row == this.rows-1;

            if(!firstCol) { this.tileMap[position-1].IncrementNearbyMines();} // increment only if its not on col 0 (update left)
            // if position is not last column (update right)
            if(!lastCol) {this.tileMap[position+1].IncrementNearbyMines();}

            // upper row update [1 row = num of cols]
            if(!firstRow) {this.tileMap[position-this.columns].IncrementNearbyMines();
            if(!firstCol) { this.tileMap[position-1-this.columns].IncrementNearbyMines();} // increment only if its not on col 0 (update left)
            // if position is not last column (update right)
            if(!lastCol) {this.tileMap[position+1-this.columns].IncrementNearbyMines();}}

            // LOWER ROW UPDATE
            if(!isLastRow) {this.tileMap[position+this.columns].IncrementNearbyMines();
            if(!firstCol) { this.tileMap[position-1+this.columns].IncrementNearbyMines();} // increment only if its not on col 0 (update left)
            // if position is not last column (update right)
            if(!lastCol) {this.tileMap[position+1+this.columns].IncrementNearbyMines();}}
            


            
        }
    }
}