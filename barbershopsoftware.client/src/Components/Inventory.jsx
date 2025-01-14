import {useState, useEffect} from "react";
import api from "../services/api";

const Inventory = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await api.get("/products");
                setProducts(response.data);
            } catch (error) {
                console.error("Error fetching products:", error);
            }
        };
        fetchProducts();
    }, []);

    return (
        <div>
            <h2>Inventory</h2>
            <ul>
                {products.map((product) => (
                    <li key={product.id}>{product.name} - {product.stock} units - ${product.price}</li>
                ))}
            </ul>
        </div>
    );
};

export default Inventory;