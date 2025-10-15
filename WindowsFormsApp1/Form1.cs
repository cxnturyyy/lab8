using System;
using System.Collections.Generic;
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
                MessageBox.Show("Введите марку и модель автомобиля!");
                return;
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
    }
}