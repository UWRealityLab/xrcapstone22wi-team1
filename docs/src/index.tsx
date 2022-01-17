import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { HashRouter, Routes, Route } from "react-router-dom";
import { ThemeProvider } from "@mui/material/styles";
import theme from "./theme";
import Template from "./components/Template";
import Index from "./pages/Index";
import Blog from "./pages/Blog";
import BlogContent from "./pages/BlogContent";
import "./index.css";

ReactDOM.render(
    <React.StrictMode>
        <ThemeProvider theme={theme}>
            <HashRouter>
                <Routes>
                    <Route path="/" element={<App />}>
                        <Route
                            index
                            element={
                                <Template
                                    title="CSE2 Virtual Tour"
                                    element={<Index />}
                                />
                            }
                        />
                        <Route
                            path="blogs"
                            element={
                                <Template title="Blogs" element={<Blog />} />
                            }
                        />
                        <Route
                            path="blogs/:week"
                            element={
                                <Template
                                    title="Blogs"
                                    element={<BlogContent />}
                                />
                            }
                        />
                    </Route>
                </Routes>
            </HashRouter>
        </ThemeProvider>
    </React.StrictMode>,
    document.getElementById("root")
);
