using Client.Logic;
using Terminal.Gui;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
        mark:
            try
            {

                WindowLogic.Execute();
            }
            catch (Exception ex)
            {
                MessageBox.Query("Ошибка", $"Пожалуйста, обратитесь к системному администратору.\nСообщение для отладки: {ex.Message}", "OK");
                goto mark;
            }
        }
    }
}


