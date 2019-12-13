using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    /*<DataGrid.Columns>
                <DataGridTextColumn x:Name="INV" Header ="INV" Binding="{Binding Path=INV,Mode=Default}"/>
                <DataGridTextColumn x:Name="CanNum" Header ="Can #"/>
                <DataGridTextColumn x:Name="Code" Header ="Code"/>
                <DataGridTextColumn x:Name="CollDate" Header ="Collection Date"/>
                <DataGridTextColumn x:Name="Units" Header ="Units"/>
                <DataGridTextColumn x:Name="AnimalName" Header ="Animal Name"/>
                <DataGridTextColumn x:Name="Breed" Header ="Breed"/>
                <DataGridTextColumn x:Name="RegNum" Header ="Reg #"/>
                <DataGridTextColumn x:Name="Owner" Header ="Owner"/>
                <DataGridTextColumn x:Name="Town" Header ="Town"/>
                <DataGridTextColumn x:Name="ST" Header ="ST"/>
            </DataGrid.Columns>*/
    public class SearchResult
    {
        private string inv;
        public string INV
        {
            get
            {
                return this.inv;
            }
            set
            {
                this.inv = value;
            }
        }
        private string canNum;
        public string CanNum
        {
            get
            {
                return this.canNum;
            }
            set
            {
                this.canNum = value;
            }
        }
        private string code;
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }
        private string collDate;
        public string CollDate
        {
            get
            {
                return this.collDate;
            }
            set
            {
                this.collDate = value;
            }
        }
        private string units;
        public string Units
        {
            get
            {
                return this.units;
            }
            set
            {
                this.units = value;
            }
        }
        private string animalName;
        public string AnimalName
        {
            get
            {
                return this.animalName;
            }
            set
            {
                this.animalName = value;
            }
        }
        private string breed;
        public string Breed
        {
            get
            {
                return this.breed;
            }
            set
            {
                this.breed = value;
            }
        }
        private string regNum;
        public string RegNum
        {
            get
            {
                return this.regNum;
            }
            set
            {
                this.regNum = value;
            }
        }
        private string owner;
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }
        private string town;
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
            }
        }
        private string state;
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }
        public SearchResult(string valid, string canNum, string code, string collDate, string units, string animalName, string breed, string regNum, string owner, string town, string state)
        {
            this.INV = valid;
            this.CanNum = canNum;
            this.Code = code;
            this.CollDate = collDate;
            this.Units = units;
            this.AnimalName = animalName;
            this.Breed = breed;
            this.RegNum = regNum;
            this.Owner = owner;
            this.Town = town;
            this.State = state;
        }
    }
}
