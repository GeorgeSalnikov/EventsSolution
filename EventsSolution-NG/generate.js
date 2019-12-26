var faker = require('faker');

var database = { events: [], products: []};

for (var i = 1; i<= 300; i++) {
  database.events.push({
    id: i,
    title: faker.commerce.productName(),
    description: faker.lorem.sentences(),
    date: faker.random.number()
  });
  database.products.push({
    id: i,
    name: faker.commerce.productName(),
    description: faker.lorem.sentences(),
    price: faker.commerce.price(),
    imageUrl: "https://source.unsplash.com/1600x900/?product",
    quantity: faker.random.number()
  });
}


console.log(JSON.stringify(database));