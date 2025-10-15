using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl1;
        private TabPage tabPageCars;
        private TabPage tabPageClients;
        private TabPage tabPageSales;

        // Элементы для вкладки автомобилей
        private ListBox listBoxCars;
        private TextBox textBoxBrand;
        private TextBox textBoxModel;
        private TextBox textBoxYear;
        private TextBox textBoxPrice;
        private Button buttonAddCar;
        private Button buttonDeleteCar;
        private Label labelCarCount;
        private Label labelBrand;
        private Label labelModel;
        private Label labelYear;
        private Label labelPrice;

        // Новые элементы для сортировки и поиска автомобилей
        private Button buttonSortCars;
        private TextBox textBoxSearchCars;
        private Button buttonSearchCars;
        private Button buttonClearSearchCars;
        private Label labelSearchCars;

        // Элементы для вкладки клиентов
        private ListBox listBoxClients;
        private TextBox textBoxClientName;
        private TextBox textBoxPhone;
        private Button buttonAddClient;
        private Label labelClientCount;
        private Label labelClientName;
        private Label labelPhone;

        // Новые элементы для сортировки и поиска клиентов
        private Button buttonSortClients;
        private TextBox textBoxSearchClients;
        private Button buttonSearchClients;
        private Button buttonClearSearchClients;
        private Label labelSearchClients;

        // Элементы для вкладки продаж
        private ListBox listBoxSales;
        private ComboBox comboBoxClients;
        private ComboBox comboBoxCars;
        private Button buttonAddSale;
        private Label labelSaleCount;
        private Label labelSelectClient;
        private Label labelSelectCar;

        // Новые элементы для сортировки и поиска продаж
        private Button buttonSortSales;
        private TextBox textBoxSearchSales;
        private Button buttonSearchSales;
        private Button buttonClearSearchSales;
        private Label labelSearchSales;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCars = new System.Windows.Forms.TabPage();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.tabPageSales = new System.Windows.Forms.TabPage();

            // Настройка главной формы
            this.SuspendLayout();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "ИС Автосалон";

            // Настройка TabControl
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Size = new System.Drawing.Size(776, 476);
            this.tabControl1.Controls.Add(this.tabPageCars);
            this.tabControl1.Controls.Add(this.tabPageClients);
            this.tabControl1.Controls.Add(this.tabPageSales);

            // Инициализация вкладки автомобилей
            InitializeCarsTab();

            // Инициализация вкладки клиентов
            InitializeClientsTab();

            // Инициализация вкладки продаж
            InitializeSalesTab();

            this.Controls.Add(this.tabControl1);
            this.ResumeLayout(false);
        }

        private void InitializeCarsTab()
        {
            this.tabPageCars.Text = "Автомобили";
            this.tabPageCars.Location = new System.Drawing.
Point(4, 22);
            this.tabPageCars.Size = new System.Drawing.Size(768, 450);
            this.tabPageCars.BackColor = System.Drawing.Color.LightGray;

            // ListBox для автомобилей
            this.listBoxCars = new ListBox();
            this.listBoxCars.Location = new System.Drawing.Point(20, 20);
            this.listBoxCars.Size = new System.Drawing.Size(400, 200);

            // Элементы поиска автомобилей
            this.labelSearchCars = new Label();
            this.labelSearchCars.Location = new System.Drawing.Point(20, 230);
            this.labelSearchCars.Size = new System.Drawing.Size(100, 20);
            this.labelSearchCars.Text = "Поиск:";

            this.textBoxSearchCars = new TextBox();
            this.textBoxSearchCars.Location = new System.Drawing.Point(70, 230);
            this.textBoxSearchCars.Size = new System.Drawing.Size(150, 20);

            this.buttonSearchCars = new Button();
            this.buttonSearchCars.Location = new System.Drawing.Point(230, 230);
            this.buttonSearchCars.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchCars.Text = "Найти";
            this.buttonSearchCars.BackColor = System.Drawing.Color.LightBlue;

            this.buttonClearSearchCars = new Button();
            this.buttonClearSearchCars.Location = new System.Drawing.Point(315, 230);
            this.buttonClearSearchCars.Size = new System.Drawing.Size(75, 23);
            this.buttonClearSearchCars.Text = "Очистить";
            this.buttonClearSearchCars.BackColor = System.Drawing.Color.LightCoral;

            // Кнопка сортировки автомобилей
            this.buttonSortCars = new Button();
            this.buttonSortCars.Location = new System.Drawing.Point(20, 260);
            this.buttonSortCars.Size = new System.Drawing.Size(120, 30);
            this.buttonSortCars.Text = "Сортировать А-Я";
            this.buttonSortCars.BackColor = System.Drawing.Color.LightGreen;

            // Метки для полей ввода
            this.labelBrand = new Label();
            this.labelBrand.Location = new System.Drawing.Point(450, 20);
            this.labelBrand.Size = new System.Drawing.Size(200, 20);
            this.labelBrand.Text = "Марка:";

            this.textBoxBrand = new TextBox();
            this.textBoxBrand.Location = new System.Drawing.Point(450, 40);
            this.textBoxBrand.Size = new System.Drawing.Size(200, 20);

            this.labelModel = new Label();
            this.labelModel.Location = new System.Drawing.Point(450, 70);
            this.labelModel.Size = new System.Drawing.Size(200, 20);
            this.labelModel.Text = "Модель:";

            this.textBoxModel = new TextBox();
            this.textBoxModel.Location = new System.Drawing.Point(450, 90);
            this.textBoxModel.Size = new System.Drawing.Size(200, 20);

            this.labelYear = new Label();
            this.labelYear.Location = new System.Drawing.Point(450, 120);
            this.labelYear.Size = new System.Drawing.Size(200, 20);
            this.labelYear.Text = "Год:";

            this.textBoxYear = new TextBox();
            this.textBoxYear.Location = new System.Drawing.Point(450, 140);
            this.textBoxYear.Size = new System.Drawing.Size(200, 20);

            this.labelPrice = new Label();
            this.labelPrice.Location = new System.Drawing.Point(450, 170);
            this.labelPrice.Size = new System.Drawing.Size(200, 20);
            this.labelPrice.Text = "Цена:";

            this.textBoxPrice = new TextBox();
            this.textBoxPrice.Location = new System.Drawing.Point(450, 190);
            this.textBoxPrice.Size = new System.Drawing.Size(200, 20);

            // Кнопки
            this.buttonAddCar = new Button();
            this.buttonAddCar.Location = new System.Drawing.Point(450, 230);
            this.buttonAddCar.Size = new System.Drawing.
Size(95, 30);
            this.buttonAddCar.Text = "Добавить";
            this.buttonAddCar.BackColor = System.Drawing.Color.LightGreen;

            this.buttonDeleteCar = new Button();
            this.buttonDeleteCar.Location = new System.Drawing.Point(555, 230);
            this.buttonDeleteCar.Size = new System.Drawing.Size(95, 30);
            this.buttonDeleteCar.Text = "Удалить";
            this.buttonDeleteCar.BackColor = System.Drawing.Color.LightCoral;

            // Метка количества
            this.labelCarCount = new Label();
            this.labelCarCount.Location = new System.Drawing.Point(20, 300);
            this.labelCarCount.Size = new System.Drawing.Size(200, 20);
            this.labelCarCount.Text = "Автомобилей: 0";

            // Добавление элементов на вкладку
            this.tabPageCars.Controls.Add(listBoxCars);
            this.tabPageCars.Controls.Add(labelSearchCars);
            this.tabPageCars.Controls.Add(textBoxSearchCars);
            this.tabPageCars.Controls.Add(buttonSearchCars);
            this.tabPageCars.Controls.Add(buttonClearSearchCars);
            this.tabPageCars.Controls.Add(buttonSortCars);
            this.tabPageCars.Controls.Add(labelBrand);
            this.tabPageCars.Controls.Add(textBoxBrand);
            this.tabPageCars.Controls.Add(labelModel);
            this.tabPageCars.Controls.Add(textBoxModel);
            this.tabPageCars.Controls.Add(labelYear);
            this.tabPageCars.Controls.Add(textBoxYear);
            this.tabPageCars.Controls.Add(labelPrice);
            this.tabPageCars.Controls.Add(textBoxPrice);
            this.tabPageCars.Controls.Add(buttonAddCar);
            this.tabPageCars.Controls.Add(buttonDeleteCar);
            this.tabPageCars.Controls.Add(labelCarCount);
        }

        private void InitializeClientsTab()
        {
            this.tabPageClients.Text = "Клиенты";
            this.tabPageClients.Location = new System.Drawing.Point(4, 22);
            this.tabPageClients.Size = new System.Drawing.Size(768, 450);
            this.tabPageClients.BackColor = System.Drawing.Color.LightBlue;

            // ListBox для клиентов
            this.listBoxClients = new ListBox();
            this.listBoxClients.Location = new System.Drawing.Point(20, 20);
            this.listBoxClients.Size = new System.Drawing.Size(400, 200);

            // Элементы поиска клиентов
            this.labelSearchClients = new Label();
            this.labelSearchClients.Location = new System.Drawing.Point(20, 230);
            this.labelSearchClients.Size = new System.Drawing.Size(100, 20);
            this.labelSearchClients.Text = "Поиск:";

            this.textBoxSearchClients = new TextBox();
            this.textBoxSearchClients.Location = new System.Drawing.Point(70, 230);
            this.textBoxSearchClients.Size = new System.Drawing.Size(150, 20);

            this.buttonSearchClients = new Button();
            this.buttonSearchClients.Location = new System.Drawing.Point(230, 230);
            this.buttonSearchClients.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchClients.Text = "Найти";
            this.buttonSearchClients.BackColor = System.Drawing.Color.LightBlue;

            this.buttonClearSearchClients = new Button();
            this.buttonClearSearchClients.Location = new System.Drawing.Point(315, 230);
            this.buttonClearSearchClients.Size = new System.Drawing.Size(75, 23);
            this.buttonClearSearchClients.Text = "Очистить";
            this.buttonClearSearchClients.BackColor = System.Drawing.Color.LightCoral;

            // Кнопка сортировки клиентов
            this.buttonSortClients = new Button();
            this.buttonSortClients.Location = new System.Drawing.Point(20, 260);
            this.buttonSortClients.Size = new System.Drawing.Size(120, 30);
            this.buttonSortClients.Text = "Сортировать А-Я";
            this.buttonSortClients.BackColor = System.
Drawing.Color.LightGreen;

            // Метки для полей ввода
            this.labelClientName = new Label();
            this.labelClientName.Location = new System.Drawing.Point(450, 20);
            this.labelClientName.Size = new System.Drawing.Size(200, 20);
            this.labelClientName.Text = "ФИО клиента:";

            this.textBoxClientName = new TextBox();
            this.textBoxClientName.Location = new System.Drawing.Point(450, 40);
            this.textBoxClientName.Size = new System.Drawing.Size(200, 20);

            this.labelPhone = new Label();
            this.labelPhone.Location = new System.Drawing.Point(450, 70);
            this.labelPhone.Size = new System.Drawing.Size(200, 20);
            this.labelPhone.Text = "Телефон:";

            this.textBoxPhone = new TextBox();
            this.textBoxPhone.Location = new System.Drawing.Point(450, 90);
            this.textBoxPhone.Size = new System.Drawing.Size(200, 20);

            // Кнопка
            this.buttonAddClient = new Button();
            this.buttonAddClient.Location = new System.Drawing.Point(450, 130);
            this.buttonAddClient.Size = new System.Drawing.Size(200, 30);
            this.buttonAddClient.Text = "Добавить клиента";
            this.buttonAddClient.BackColor = System.Drawing.Color.LightYellow;

            // Метка количества
            this.labelClientCount = new Label();
            this.labelClientCount.Location = new System.Drawing.Point(20, 300);
            this.labelClientCount.Size = new System.Drawing.Size(200, 20);
            this.labelClientCount.Text = "Клиентов: 0";

            // Добавление элементов на вкладку
            this.tabPageClients.Controls.Add(listBoxClients);
            this.tabPageClients.Controls.Add(labelSearchClients);
            this.tabPageClients.Controls.Add(textBoxSearchClients);
            this.tabPageClients.Controls.Add(buttonSearchClients);
            this.tabPageClients.Controls.Add(buttonClearSearchClients);
            this.tabPageClients.Controls.Add(buttonSortClients);
            this.tabPageClients.Controls.Add(labelClientName);
            this.tabPageClients.Controls.Add(textBoxClientName);
            this.tabPageClients.Controls.Add(labelPhone);
            this.tabPageClients.Controls.Add(textBoxPhone);
            this.tabPageClients.Controls.Add(buttonAddClient);
            this.tabPageClients.Controls.Add(labelClientCount);
        }

        private void InitializeSalesTab()
        {
            this.tabPageSales.Text = "Продажи";
            this.tabPageSales.Location = new System.Drawing.Point(4, 22);
            this.tabPageSales.Size = new System.Drawing.Size(768, 450);
            this.tabPageSales.BackColor = System.Drawing.Color.LightGoldenrodYellow;

            // ListBox для продаж
            this.listBoxSales = new ListBox();
            this.listBoxSales.Location = new System.Drawing.Point(20, 20);
            this.listBoxSales.Size = new System.Drawing.Size(500, 200);

            // Элементы поиска продаж
            this.labelSearchSales = new Label();
            this.labelSearchSales.Location = new System.Drawing.Point(20, 230);
            this.labelSearchSales.Size = new System.Drawing.Size(100, 20);
            this.labelSearchSales.Text = "Поиск:";

            this.textBoxSearchSales = new TextBox();
            this.textBoxSearchSales.Location = new System.Drawing.Point(70, 230);
            this.textBoxSearchSales.Size = new System.Drawing.Size(150, 20);

            this.buttonSearchSales = new Button();
            this.buttonSearchSales.Location = new System.Drawing.Point(230, 230);
            this.buttonSearchSales.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchSales.Text = "Найти";
            this.buttonSearchSales.BackColor = System.Drawing.Color.LightBlue;

            this.buttonClearSearchSales = new Button();
            this.
buttonClearSearchSales.Location = new System.Drawing.Point(315, 230);
            this.buttonClearSearchSales.Size = new System.Drawing.Size(75, 23);
            this.buttonClearSearchSales.Text = "Очистить";
            this.buttonClearSearchSales.BackColor = System.Drawing.Color.LightCoral;

            // Кнопка сортировки продаж
            this.buttonSortSales = new Button();
            this.buttonSortSales.Location = new System.Drawing.Point(20, 260);
            this.buttonSortSales.Size = new System.Drawing.Size(120, 30);
            this.buttonSortSales.Text = "Сортировать А-Я";
            this.buttonSortSales.BackColor = System.Drawing.Color.LightGreen;

            // Метки для ComboBox
            this.labelSelectClient = new Label();
            this.labelSelectClient.Location = new System.Drawing.Point(20, 300);
            this.labelSelectClient.Size = new System.Drawing.Size(200, 20);
            this.labelSelectClient.Text = "Выберите клиента:";

            this.comboBoxClients = new ComboBox();
            this.comboBoxClients.Location = new System.Drawing.Point(20, 320);
            this.comboBoxClients.Size = new System.Drawing.Size(200, 20);
            this.comboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;

            this.labelSelectCar = new Label();
            this.labelSelectCar.Location = new System.Drawing.Point(240, 300);
            this.labelSelectCar.Size = new System.Drawing.Size(200, 20);
            this.labelSelectCar.Text = "Выберите автомобиль:";

            this.comboBoxCars = new ComboBox();
            this.comboBoxCars.Location = new System.Drawing.Point(240, 320);
            this.comboBoxCars.Size = new System.Drawing.Size(200, 20);
            this.comboBoxCars.DropDownStyle = ComboBoxStyle.DropDownList;

            // Кнопка
            this.buttonAddSale = new Button();
            this.buttonAddSale.Location = new System.Drawing.Point(460, 320);
            this.buttonAddSale.Size = new System.Drawing.Size(120, 25);
            this.buttonAddSale.Text = "Оформить продажу";
            this.buttonAddSale.BackColor = System.Drawing.Color.Gold;

            // Метка количества
            this.labelSaleCount = new Label();
            this.labelSaleCount.Location = new System.Drawing.Point(20, 350);
            this.labelSaleCount.Size = new System.Drawing.Size(200, 20);
            this.labelSaleCount.Text = "Продаж: 0";

            // Добавление элементов на вкладку
            this.tabPageSales.Controls.Add(listBoxSales);
            this.tabPageSales.Controls.Add(labelSearchSales);
            this.tabPageSales.Controls.Add(textBoxSearchSales);
            this.tabPageSales.Controls.Add(buttonSearchSales);
            this.tabPageSales.Controls.Add(buttonClearSearchSales);
            this.tabPageSales.Controls.Add(buttonSortSales);
            this.tabPageSales.Controls.Add(labelSelectClient);
            this.tabPageSales.Controls.Add(comboBoxClients);
            this.tabPageSales.Controls.Add(labelSelectCar);
            this.tabPageSales.Controls.Add(comboBoxCars);
            this.tabPageSales.Controls.Add(buttonAddSale);
            this.tabPageSales.Controls.Add(labelSaleCount);
        }
    }
}