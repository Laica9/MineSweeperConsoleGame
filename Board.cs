using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minesweep
{
    public class Board
    {
        private GameState state;
        private Tile[] tileMap; // array of tile objects
        private int number_of_mines, rows, columns;
        private string newL = Environment.NewLine;

        public Board() {}

        // Methods -------------------------------------------------------
        /// <summary>
        /// 
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
            InsertMines(this.tileMap, number_of_mines);
        }

        public bool GameOver() {return this.state == GameState.GAME_LOST;}
        public bool Win() {return this.state == GameState.GAME_WON;}
        
        private Tile[] MakeEmptyTileMap(int rows, int columns) {
            Tile[] tile = new Tile[rows*columns];
            for(int row=0;row<this.rows;row++) {
                for(int col=0;col<this.columns;col++) {
                    tile[col + row * this.columns] = new Tile();
                }
            }
            return tile;
        }

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

        private void IncrementNearMines(Tile[] tileArr, int position) {
            
        }
    }
}