using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minesweep
{
    public class Tile
    {
        private bool hidden; // '.'
        private bool isMine; // '*'
        private char tile; // ' ', 'f', '?'
        private char emptyTile = ' ';
        private char flagTile = 'f';
        private char unknown = '?';
        private int nearbyMines;

        public Tile () {
            this.isMine = false; // by default
            this.hidden = true;
            this.tile = ' ';
            this.nearbyMines = 0;
        }

        // Get/Set ----------------------------
        public bool IsMine() {
            return isMine;
        }

        public void SetMine() {
            this.isMine = true;
        }

        public bool Hidden() {
            return hidden;
        }

        public void SetHidden(bool hidden) {
            this.hidden = hidden;
        }

        public int GetNearbyMines() {
            return nearbyMines;
        }

        public void SetNearbyMines(int nearbyMines) {
            this.nearbyMines = nearbyMines;
        }

        public void IncrementNearbyMines() {
            this.nearbyMines++;
        }

        public void Reveal() {
            this.hidden = false;
        }

        public char GetTile() {
            return tile;
        }

        public void setTile(char tile) {
            this.tile = tile;
        }
        // methods --------------------------
        public bool IsUnmarked() {
            return this.tile == this.emptyTile;
        }

        //switch states.
        public void switcheTile() {
            if(this.tile == this.emptyTile) {this.tile = this.flagTile;}
            else if(this.tile == this.flagTile) {this.tile = this.unknown;}
            else if(this.tile == this.unknown) {this.tile = this.emptyTile;}
        }

        public string DrawTile() {
            String draw;
            if(this.Hidden()) {
                if(this.tile == this.unknown) {
                    draw = "?";
                }else if(this.tile == this.flagTile) {draw = "f";}
                else {draw = ".";} // default
            }else {
                if(this.isMine) {draw = "*";}
                else{if(this.nearbyMines == 0) {
                    draw = "0";
                }else {
                    draw = Convert.ToString(this.nearbyMines);
                }
             }
            }

                return draw;
        }
    }
}