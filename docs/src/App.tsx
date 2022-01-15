import {} from "react-router";
import { HashRouter, Routes, Route } from "react-router-dom";
import Nav from "./components/Nav";
import { ThemeProvider } from "@mui/material/styles";
import theme from "./theme";
const App = () => {
    return (
        <ThemeProvider theme={theme}>
            <HashRouter>
                <Nav />
                <Routes>
                    <Route path="/" element={<Index />} />
                </Routes>
            </HashRouter>
        </ThemeProvider>
    );
};

export default App;
