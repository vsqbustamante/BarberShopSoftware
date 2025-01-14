import { createContext, useState } from "react";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";
import api, { setAuthToken } from "../services/api";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const navigate = useNavigate();

    const login = async (credentials) => {
        try {
            const { data } = await api.post("/auth/login", credentials);
            setAuthToken(data.token);
            setUser({ username: credentials.username, role: data.role });
            navigate("/dashboard");
        } catch (error) {
            console.error("Login failed:", error);
        }
    };

    const logout = () => {
        setAuthToken(null);
        setUser(null);
        navigate("/login");
    };

    return (
        <AuthContext.Provider value={{ user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

AuthProvider.propTypes = {
    children: PropTypes.node.isRequired,
};
