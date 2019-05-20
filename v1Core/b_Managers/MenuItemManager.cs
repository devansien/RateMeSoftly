using System.Collections.Generic;

namespace RateMeSoftly
{
    public class MenuItemManager
    {
        public List<MenuItem> MenuItems;

        public MenuItemManager()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Index = 0,
                    Name = "Message",
                    Thumbnail = "https://s3.amazonaws.com/sonnar-polyglot/flags/random.jpg",
                    Background = "https://s3.amazonaws.com/sonnar-polyglot/flags/random.jpg"
                },
                new MenuItem
                {
                    Index = 1,
                    Name = "Schedule",
                    Thumbnail = "https://s3.amazonaws.com/sonnar-polyglot/flags/france.jpg",
                    Background = "https://s3.amazonaws.com/sonnar-polyglot/flags/france.jpg"
                },
                new MenuItem
                {
                    Index = 2,
                    Name = "Meals",
                    Thumbnail = "https://s3.amazonaws.com/sonnar-polyglot/flags/italy.jpg",
                    Background = "https://s3.amazonaws.com/sonnar-polyglot/flags/italy.jpg"
                },
                new MenuItem
                {
                    Index = 3,
                    Name = "Sonnar",
                    Thumbnail = "https://s3.amazonaws.com/sonnar-polyglot/flags/germany.jpg",
                    Background = "https://s3.amazonaws.com/sonnar-polyglot/flags/germany.jpg"
                },
                new MenuItem
                {
                    Index = 4,
                    Name = "Health",
                    Thumbnail = "https://s3.amazonaws.com/sonnar-polyglot/flags/spain.jpg",
                    Background = "https://s3.amazonaws.com/sonnar-polyglot/flags/spain.jpg"
                },
                new MenuItem
                {
                    Index = 5,
                    Name = "Call",
                    Thumbnail = "https://s3.amazonaws.com/sonnar-polyglot/flags/japan.jpg",
                    Background = "https://s3.amazonaws.com/sonnar-polyglot/flags/japan.jpg"
                }
            };
        }

        public int GetCount()
        {
            return MenuItems.Count;
        }

        public List<MenuItem> GetAll()
        {
            return MenuItems;
        }
    }
}
