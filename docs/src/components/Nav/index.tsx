import { useState, MouseEvent } from "react";
import {
    AppBar,
    Box,
    Toolbar,
    IconButton,
    Typography,
    Menu,
    Container,
    Button,
    MenuItem,
} from "@mui/material";
import GitHubIcon from "@mui/icons-material/GitHub";
import MenuIcon from "@mui/icons-material/Menu";
import { Link } from "react-router-dom";

const pages = [
    { name: "Blogs", route: "blogs" },
    { name: "Product Requirements", route: "product" },
    { name: "Demo", route: "demo" },
];

const Nav = () => {
    const [anchorElNav, setAnchorElNav] = useState<null | HTMLElement>(null);
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

    const isMenuOpen = Boolean(anchorEl);

    const handleMenuClose = () => {
        setAnchorEl(null);
    };

    const handleOpenNavMenu = (event: MouseEvent<HTMLElement>) => {
        setAnchorElNav(event.currentTarget);
    };

    const handleCloseNavMenu = () => {
        setAnchorElNav(null);
    };

    const renderMenu = (
        <Menu
            anchorEl={anchorEl}
            anchorOrigin={{
                vertical: "top",
                horizontal: "right",
            }}
            keepMounted
            transformOrigin={{
                vertical: "top",
                horizontal: "right",
            }}
            open={isMenuOpen}
            onClose={handleMenuClose}
        >
            {pages.map((page) => (
                <MenuItem key={page.name} onClick={handleMenuClose}>
                    <Link to={"/" + page.route}>{page.name}</Link>
                </MenuItem>
            ))}
        </Menu>
    );

    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static">
                <Container maxWidth="xl">
                    <Toolbar disableGutters>
                        <Link to="/">
                            <Typography
                                variant="h6"
                                noWrap
                                component="div"
                                align="center"
                                sx={{
                                    mr: 2,
                                    display: { xs: "none", md: "flex" },
                                    textAlign: "center",
                                }}
                            >
                                VR
                            </Typography>
                        </Link>
                        <Box
                            sx={{
                                flexGrow: 1,
                                display: { xs: "flex", md: "none" },
                            }}
                        >
                            <IconButton
                                size="large"
                                onClick={handleOpenNavMenu}
                                color="inherit"
                            >
                                <MenuIcon />
                            </IconButton>
                            <Menu
                                id="menu-appbar"
                                anchorEl={anchorElNav}
                                anchorOrigin={{
                                    vertical: "bottom",
                                    horizontal: "left",
                                }}
                                keepMounted
                                transformOrigin={{
                                    vertical: "top",
                                    horizontal: "left",
                                }}
                                open={Boolean(anchorElNav)}
                                onClose={handleCloseNavMenu}
                                sx={{
                                    display: { xs: "block", md: "none" },
                                }}
                            >
                                {pages.map((page) => (
                                    <MenuItem
                                        key={page.name}
                                        onClick={handleCloseNavMenu}
                                    >
                                        <Link to={"/" + page.route}>
                                            <Typography textAlign="center">
                                                {page.name}
                                            </Typography>
                                        </Link>
                                    </MenuItem>
                                ))}
                            </Menu>
                        </Box>
                        <Link to="/">
                            <Typography
                                variant="h6"
                                noWrap
                                sx={{
                                    textAlign: "center",
                                    flexGrow: 1,
                                    display: { xs: "inline", md: "none" },
                                }}
                            >
                                VR
                            </Typography>
                        </Link>
                        <Box
                            sx={{
                                flexGrow: 1,
                                display: { xs: "none", md: "flex" },
                            }}
                        >
                            {pages.map((page) => (
                                <Link key={page.name} to={"/" + page.route}>
                                    <Button
                                        onClick={handleCloseNavMenu}
                                        sx={{
                                            my: 2,
                                            color: "white",
                                            display: "block",
                                            textTransform: "unset",
                                        }}
                                    >
                                        {page.name}
                                    </Button>
                                </Link>
                            ))}
                        </Box>
                        <Box sx={{ flexGrow: 1 }} />
                        <Box>
                            <a
                                href="https://github.com/UWRealityLab/xrcapstone22wi-team1"
                                target="_blank"
                                rel="noreferrer"
                            >
                                <IconButton size="large" color="inherit">
                                    <GitHubIcon />
                                </IconButton>
                            </a>
                        </Box>
                    </Toolbar>
                </Container>
            </AppBar>
            {renderMenu}
        </Box>
    );
};
export default Nav;
