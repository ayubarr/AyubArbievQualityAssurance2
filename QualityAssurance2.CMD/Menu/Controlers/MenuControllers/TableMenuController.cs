using AyubArbievQualityAssurance2.Data.Models.Common;

namespace QualityAssurance2.CMD.Menu.Controlers.MenuControllers
{
    public static class TableMenuController<T> where T : BaseEntity
    {

        public static void TableMenuButtons()
        {

            ViewTableMenuInfo();
            string choice = ClickCheck();
            switch (choice)
            {
                case "1":
                    Console.Clear();

                    break;

                case "2":
                    Console.Clear();
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Clear();
                    break;

                case "Backspace":
                    Console.Clear();
                    break;
                case "Escape":
                    Environment.Exit(0);
                    break;
            }
        }
        private static string ClickCheck()
        {

            string[] keys = new string[]
            {
                    "1",
                    "2",
                    "3",
                    "4",
                    "Escape",
                    "Backspace",
            };
            string choiceButtom = ButtonController.Button(keys);
            return choiceButtom;
        }
        private static void ViewTableMenuInfo()
        {
            Console.WriteLine(
                "[1] - Add\n" +
               "[2] - Edit \n" +
               "[3] - Delete)" +
               "[4] - Show client’s orders" +
               "[Back] - Return)" +
               "[Esc] - Exit"
               );
        }
    }
}
