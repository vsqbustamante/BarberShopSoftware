import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:54276/',
});

export const setAuthToken = (token) => {
    if (token) {
        api.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    } else {
        delete api.defaults.headers.common["Authorization"];
    }
};

export const fetchSales = async () => {
    const response = await api.get("/sales");
    return response.data;
};

export const createSales = async (sales) => {
    const response = await api.post("/sales", sales);
    return response.data;
};
export default api;
