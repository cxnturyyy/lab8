using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Простые списки для хранения данных (вместо БД)
        private List<string> cars = new List<string>();
        private List<string> clients = new List<string>();
        private List<string> sales = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Добавляем обработчики событий
            buttonAddCar.Click += ButtonAddCar_Click;
            buttonDeleteCar.Click += ButtonDeleteCar_Click;
            buttonAddClient.Click += ButtonAddClient_Click;
            buttonAddSale.Click += ButtonAddSale_Click;

            // Обработчики для сортировки и поиска
            buttonSortCars.Click += ButtonSortCars_Click;
            buttonSortClients.Click += ButtonSortClients_Click;
            buttonSortSales.Click += ButtonSortSales_Click;
            buttonSearchCars.Click += ButtonSearchCars_Click;
            buttonSearchClients.Click += ButtonSearchClients_Click;
            buttonSearchSales.Click += ButtonSearchSales_Click;
            buttonClearSearchCars.Click += ButtonClearSearchCars_Click;
            buttonClearSearchClients.Click += ButtonClearSearchClients_Click;
            buttonClearSearchSales.Click += ButtonClearSearchSales_Click;

            // Добавляем тестовые данные
            AddTestData();

            // Обновляем отображение
            UpdateDisplay();
        }

        private void AddTestData()
        {
            // Тестовые автомобили
            cars.Add("Toyota Camry | 2022 | 2 500 000 руб.");
            cars.Add("Honda CR-V | 2023 | 3 200 000 руб.");
            cars.Add("BMW X5 | 2021 | 4 500 000 руб.");

            // Тестовые клиенты
            clients.Add("Иванов Иван | +7-911-123-45-67");
            clients.Add("Петрова Анна | +7-912-987-65-43");

            // Тестовые продажи
            sales.Add("Иванов Иван → BMW X5 | 10.01.2024");
        }

        private void UpdateDisplay()
        {
            // Обновляем ListBox для автомобилей
            listBoxCars.Items.Clear();
            foreach (string car in cars)
            {
                listBoxCars.Items.Add(car);
            }
            labelCarCount.Text = $"Автомобилей: {cars.Count}";

            // Обновляем ListBox для клиентов
            listBoxClients.Items.Clear();
            foreach (string client in clients)
            {
                listBoxClients.Items.Add(client);
            }
            labelClientCount.Text = $"Клиентов: {clients.Count}";

            // Обновляем ListBox для продаж
            listBoxSales.Items.Clear();
            foreach (string sale in sales)
            {
                listBoxSales.Items.Add(sale);
            }
            labelSaleCount.Text = $"Продаж: {sales.Count}";

            // Обновляем ComboBox для продаж
            comboBoxClients.Items.Clear();
            foreach (string client in clients)
            {
                comboBoxClients.Items.Add(client);
            }
            if (comboBoxClients.Items.Count > 0)
                comboBoxClients.SelectedIndex = 0;

            comboBoxCars.Items.Clear();
            foreach (string car in cars)
            {
                comboBoxCars.Items.Add(car);
            }
            if (comboBoxCars.Items.Count > 0)
                comboBoxCars.SelectedIndex = 0;
        }

        // Обработчики событий
        private void ButtonAddCar_Click(object sender, EventArgs e)
        {
            string brand = textBoxBrand.Text.Trim();
            string model = textBoxModel.Text.Trim();
            string year = textBoxYear.Text.Trim();
            string price = textBoxPrice.Text.Trim();

            if (string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Введите марку и модель автомобиля!"); return;
            }

            if (string.IsNullOrEmpty(year)) year = "2024";
            if (string.IsNullOrEmpty(price)) price = "0";

            string carInfo = $"{brand} {model} | {year} | {price} руб.";
            cars.Add(carInfo);

            // Очищаем поля ввода
            textBoxBrand.Clear();
            textBoxModel.Clear();
            textBoxYear.Clear();
            textBoxPrice.Clear();

            UpdateDisplay();
            MessageBox.Show("Автомобиль добавлен!");
        }

        private void ButtonDeleteCar_Click(object sender, EventArgs e)
        {
            if (listBoxCars.SelectedIndex >= 0)
            {
                int index = listBoxCars.SelectedIndex;
                string carName = cars[index];

                DialogResult result = MessageBox.Show(
                    $"Удалить автомобиль: {carName}?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    cars.RemoveAt(index);
                    UpdateDisplay();
                    MessageBox.Show("Автомобиль удален!");
                }
            }
            else
            {
                MessageBox.Show("Выберите автомобиль для удаления!");
            }
        }

        private void ButtonAddClient_Click(object sender, EventArgs e)
        {
            string name = textBoxClientName.Text.Trim();
            string phone = textBoxPhone.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите ФИО клиента!");
                return;
            }

            if (string.IsNullOrEmpty(phone)) phone = "Телефон не указан";

            string clientInfo = $"{name} | {phone}";
            clients.Add(clientInfo);

            // Очищаем поля ввода
            textBoxClientName.Clear();
            textBoxPhone.Clear();

            UpdateDisplay();
            MessageBox.Show("Клиент добавлен!");
        }

        private void ButtonAddSale_Click(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedIndex >= 0 && comboBoxCars.SelectedIndex >= 0)
            {
                string client = clients[comboBoxClients.SelectedIndex].Split('|')[0].Trim();
                string car = cars[comboBoxCars.SelectedIndex].Split('|')[0].Trim();
                string date = DateTime.Now.ToString("dd.MM.yyyy");

                string saleInfo = $"{client} → {car} | {date}";
                sales.Add(saleInfo);

                UpdateDisplay();
                MessageBox.Show("Продажа оформлена!");
            }
            else
            {
                MessageBox.Show("Выберите клиента и автомобиль!");
            }
        }

        // Функции сортировки
        private void ButtonSortCars_Click(object sender, EventArgs e)
        {
            cars = cars.OrderBy(c => c).ToList();
            UpdateDisplay();
            MessageBox.Show("Автомобили отсортированы по алфавиту!");
        }

        private void ButtonSortClients_Click(object sender, EventArgs e)
        {
            clients = clients.OrderBy(c => c).ToList();
            UpdateDisplay();
            MessageBox.Show("Клиенты отсортированы по алфавиту!");
        }

        private void ButtonSortSales_Click(object sender, EventArgs e)
        {
            sales = sales.OrderBy(s => s).ToList();
            UpdateDisplay();
            MessageBox.Show("Продажи отсортированы по алфавиту!");
        }

        // Функции поиска
        private void ButtonSearchCars_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchCars.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска автомобилей!");
                return;
            }

            listBoxCars.Items.Clear(); foreach (string car in cars)
            {
                if (car.ToLower().Contains(searchText))
                {
                    listBoxCars.Items.Add(car);
                }
            }

            int foundCount = listBoxCars.Items.Count;
            labelCarCount.Text = $"Найдено автомобилей: {foundCount}";

            if (foundCount == 0)
            {
                MessageBox.Show("Автомобили по вашему запросу не найдены!");
            }
        }

        private void ButtonSearchClients_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchClients.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска клиентов!");
                return;
            }

            listBoxClients.Items.Clear();
            foreach (string client in clients)
            {
                if (client.ToLower().Contains(searchText))
                {
                    listBoxClients.Items.Add(client);
                }
            }

            int foundCount = listBoxClients.Items.Count;
            labelClientCount.Text = $"Найдено клиентов: {foundCount}";

            if (foundCount == 0)
            {
                MessageBox.Show("Клиенты по вашему запросу не найдены!");
            }
        }

        private void ButtonSearchSales_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchSales.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска продаж!");
                return;
            }

            listBoxSales.Items.Clear();
            foreach (string sale in sales)
            {
                if (sale.ToLower().Contains(searchText))
                {
                    listBoxSales.Items.Add(sale);
                }
            }

            int foundCount = listBoxSales.Items.Count;
            labelSaleCount.Text = $"Найдено продаж: {foundCount}";

            if (foundCount == 0)
            {
                MessageBox.Show("Продажи по вашему запросу не найдены!");
            }
        }

        // Функции очистки поиска
        private void ButtonClearSearchCars_Click(object sender, EventArgs e)
        {
            textBoxSearchCars.Clear();
            UpdateDisplay();
        }

        private void ButtonClearSearchClients_Click(object sender, EventArgs e)
        {
            textBoxSearchClients.Clear();
            UpdateDisplay();
        }

        private void ButtonClearSearchSales_Click(object sender, EventArgs e)
        {
            textBoxSearchSales.Clear();
            UpdateDisplay();
        }
    }
}