import { useEffect, useState } from "react";
import api from "../services/api";

const ClientList = () => {
    const [clients, setClients] = useState([]);

    useEffect(() => {
        const fetchClients = async () => {
            try {
                const response = await api.get("/clients");
                setClients(response.data);
            } catch (error) {
                console.error("Error fetching clients:", error);
            }
        };
        fetchClients();
    }, []);

    return (
        <div>
            <h2>Waiting List</h2>
            <ul>
                {clients.map((client) => (
                    <li key={client.id}>{client.name} - {client.contact_info}</li>
                ))}
            </ul>
        </div>
    );
};

export default ClientList;
