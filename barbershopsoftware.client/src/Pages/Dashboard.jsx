import ClientList from "../components/ClientList";
import Inventory from "../components/Inventory";
import Sales from "../components/Sales";

const Dashboard = () => {
    return (
        <div>
            <h1>Dashboard</h1>
            <ClientList />
            <Inventory />
            <Sales />
        </div>
    );
};

export default Dashboard;