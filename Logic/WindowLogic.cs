using Terminal.Gui;

namespace Client.Logic
{
    public class WindowLogic
    {
        // Общедоступные компоненты

        public static Label getResults = new Label(" Работа");

        public static Window window = new Window("Клиент информационной системы")
        {
            X = 0,
            Y = 1,

            Width = Dim.Fill(),
            Height = Dim.Fill()
        };


        // Стартовый метод

        public static void Execute()
        {

            Toplevel top = Application.Top;

            Console.Title = "REST Client";

            Application.Init();

            #region УДАЛИТЬ ПРИ СБОРКЕ ПОД МАК!!!

            Console.SetBufferSize(120, 70);
            Console.SetWindowSize(120, 70);

            #endregion

            top = Application.Top;

            MenuBarItem[] menu = new MenuBarItem[] { new MenuBarItem("Функции", new MenuItem[] {
                new MenuItem("Подключиться к серверу", "", DialogLogic.ShowConnectionDialog, () => true),
                new MenuItem("Создать запись о мелком предмете", "", DialogLogic.ShowCreationDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Создать запись об учащемся, взявшем мелкий предмет", "", DialogLogic.ShowNewBorrowerBindDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить имя учащегося, взявшего мелкий предмет", "", DialogLogic.ShowBorrowerNameUpdateDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить класс учащегося, взявшего мелкий предмет", "", DialogLogic.ShowBorrowerClassUpdateDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить здание учащегося, взявшего мелкий предмет", "", DialogLogic.ShowBorrowerBuildingUpdateDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Удалить запись об учащемся, взявшем мелкий предмет", "", DialogLogic.ShowBorrowerDeleteDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Получить запись о мелком предмете по магическому числу", "", DialogLogic.ShowGetByIdDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Получить все записи (таблица мелких предметов)", "", DialogLogic.ShowGetAllDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Поиск в таблице мелких предметов по названию", "", DialogLogic.ShowSearchDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить состояние мелкого предмета", "", DialogLogic.ShowUpdateStateDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить название мелкого предмета", "", DialogLogic.ShowUpdateNameDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить количество мелкого предмета", "", DialogLogic.ShowUpdateQuantityDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить единицу измерения мелкого предмета", "", DialogLogic.ShowUpdateUnitDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                new MenuItem("Изменить описание мелкого предмета", "", DialogLogic.ShowUpdateDescDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                 new MenuItem("Изменить владельца мелкого предмета", "", DialogLogic.ShowUpdateOwnerDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                 new MenuItem("Удалить запись о мелком предмете по магическому числу", "", DialogLogic.ShowDeleteDialog, () =>
                 (!((HTTPLogic.IP == null) || (HTTPLogic.IP == string.Empty)))),
                 new MenuItem("О программе", "", DialogLogic.ShowAboutDialog, () => true)
            }) };


            top.Add(new MenuBar(menu));

            window.Add(getResults);

            top.Add(window);

            Application.Run();

        }
    }
}

