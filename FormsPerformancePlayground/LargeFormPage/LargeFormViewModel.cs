using System;
using System.Collections.Generic;
//using PropertyChanged;
using Xamarin.Forms;

namespace FormsPerformancePlayground
{
    //[ImplementPropertyChanged]
    public class LargeFormViewModel //: FreshMvvm.FreshBasePageModel
    {
        public LargeFormViewModel()
        {
            SetupLists();
        }

        public List<String> BuildingTypeList { get; set; }
        public List<String> DesignTypeList { get; set; }
        public List<String> ConstructionTypeList { get; set; }
        public List<String> RoofTypeList { get; set; }
        public List<String> AgeList { get; set; }
        public List<String> M2List { get; set; }
        public List<String> OutBuilding1List { get; set; }

        bool YesSelected = false;
        bool NoSelected = false; //tuurn this into a list of y/n objects

        public Command YesPressed
        {
            get
            {
                return new Command(() =>
                {
                    if (YesSelected == false)
                    {
                        //color changed in YesNoFormSection
                        YesSelected = true;
                        NoSelected = false;
                    }
                });
            }
        }

        public Command NoPressed
        {
            get
            {
                return new Command(() =>
                {
                    if (NoSelected == false)
                    {
                        //color changed in YesNoFormSection
                        NoSelected = true;
                        YesSelected = false;
                    }
                });
            }
        }

        private void SetupLists()
        {
            BuildingTypeList = new List<string>()
            {
                "House",
                "Unit",
                "Apartment",
                "TownHouse",
                "Flat",
                "Terraced",
                "Semi-Detached",
                "Other"
            };

            DesignTypeList = new List<string>()
            {
                "Double Storey",
                "Single Level",
                "Multi-Level",
                "Split, Level",
                "Other"
            };

            ConstructionTypeList = new List<string>()
            {
                "Brick Veneer",
                "Vinyl Cladding",
                "Fibro",
                "Solid Board",
                "Weather Board",
                "Double Brick",
                "Concrete Panel",
                "Other",
            };

            RoofTypeList = new List<string>()
            {
                "Cement Tiles",
                "Corrugated Iron",
                "Metal Deck",
                "Terracotta",
                "Super Six",
                "Tiles/Metal",
                "Corrugated Fibro",
                "Aluminium Sheet",
                "Other",
                "Slate"
            };

            AgeList = new List<string>()
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                "11-15", "16-20",
                "21-25", "26-30",
                "31-35", "36-40",
                "41-50",
                "51-60",
                "61-70",
                "71-80",
                "81-90",
                "91-100",
                "101+"
            };

            M2List = new List<string>()
            {
                "< 100",
                "100",
                "125",
                "150",
                "175",
                "200",
                "225",
                "250",
                "275",
                "300",
                "325",
                "350",
                "375",
                "400",
                "> 400"
            };

            OutBuilding1List = new List<string>()
            {
                "Bungalow",
                "Shed (Brick)",
                "Shed (Fibro)",
                "Shred (Metal)",
                "Pool (Above Ground)",
                "Pergola",
                "Carport (Timber)",
                "Carport (Brick)",
                "Dog Kennel",
                "External Laundry",
                "Pool (Below Ground)",
                "External WC",
                "BBQ Area",
                "Pool Room",
                "Store Room",
                "Cubby House",
                "Pump Room",
                "Granny Flat",
                "Gararge (Brick)",
                "Gararge (Metal)",
                "Carport (Metal)",
                "Screen Enclosures",
                "fence",
                "N/A"
            };

        }
    }
}

