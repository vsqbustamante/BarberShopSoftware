import { useState, useEffect } from "react";
import { fetchSales, createSales } from "../services/api";
import api from "../services/api";

const Sales = () => {
    const [sales, setSales] = useState([]);
    const [products, setProducts] = useState([]);
    const [newSale, setNewSale] = useState({ productId: "", quantity: 0 });

    useEffect(() => {
        const fetchData = async () => {
            const salesData = await fetchSales();
            setSales(salesData);

            const productsData = await api.get("/products");
            setProducts(productsData.data);
        };
        fetchData();
    }, []);

    const handleSaleSubmit = async (e) => {
        e.preventDefault();
        try {
            const sale = await createSales(newSale);
            setSales([...sales, sale]);
        } catch (error) {
            console.error("Error creating sale:", error);
        }
    };

    return (
        <div>
            <h2>Sales</h2>
            <form onSubmit={handleSaleSubmit}>
                <select
                    value={newSale.productId}
                    onChange={(e) =>
                        setNewSale({ ...newSale, productId: e.target.value })
                    }
                >
                    <option value="">Select Product</option>
                    {products.map((product) => (
                        <option key={product.id} value={product.id}>
                            {product.name}
                        </option>
                    ))}
                </select>
                <input
                    type="number"
                    placeholder="Quantity"
                    value={newSale.quantity}
                    onChange={(e) =>
                        setNewSale({ ...newSale, quantity: parseInt(e.target.value) })
                    }
                />
                <button type="submit">Add Sale</button>
            </form>
            <ul>
                {sales.map((sale) => (
                    <li key={sale.id}>
                        {sale.product.name} - {sale.quantity} units - ${sale.total}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Sales;