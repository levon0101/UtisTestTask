using System.Linq;
using System.Windows;

namespace UtisTestTask.Client
{
    public static class WindowOperations
    {
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        public static void BringTop<T>(string name = "") where T : Window
        {

            var window = Application.Current.Windows.OfType<T>().FirstOrDefault();

            if (window == null) return;

            window.Topmost = true;
            window.Topmost = false;
        }
    }
}
