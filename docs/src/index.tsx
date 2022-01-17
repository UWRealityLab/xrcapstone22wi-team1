import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { HashRouter, Routes, Route } from "react-router-dom";
import { ThemeProvider } from "@mui/material/styles";
import theme from "./theme";
import Index from "./pages/Index";
import Blog from "./pages/Blog";
import "./index.css";

ReactDOM.render(
    <React.StrictMode>
        <ThemeProvider theme={theme}>
            <HashRouter>
                <Routes>
                    <Route path="/" element={<App />}>
                        <Route index element={<Index />} />
                        <Route path="blog" element={<Blog />} />
                        <Route path="blog/:week">
                            {/* <Box sx={{ marginBottom: "4em" }}>
                                <Banner title="Blog" />
                                <BlogContent />
                            </Box> */}
                        </Route>
                    </Route>
                </Routes>
            </HashRouter>
        </ThemeProvider>
    </React.StrictMode>,
    document.getElementById("root")
);
