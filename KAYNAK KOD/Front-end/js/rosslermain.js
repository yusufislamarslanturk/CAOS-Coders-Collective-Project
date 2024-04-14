var rossler = null;
var controls = null;

window.addEventListener('load', function() {
    var canvas = document.querySelector('#rossler');
    rossler = Rossler.run(canvas);
    controls = new rosslerControls(rossler);

    window.addEventListener('keypress', function(e) {
        if (e.which === '?'.charCodeAt(0)) {
            var h = document.querySelector('#help');
            h.style.display = h.style.display == 'none' ? 'block' : 'none';
        }
    });
    window.addEventListener('touchstart', function self(e) {
        var h = document.querySelector('#help');
        h.style.display = 'none';
    });

    var stats = document.querySelector('#stats');
    function update_stats() {
        var fps = rossler.fps;
        var count = rossler.solutions.length.toLocaleString();
        stats.textContent = count + ' @ ' + fps + ' FPS';
    }
    window.setInterval(update_stats, 1000);
    controls.listeners.push(update_stats);

    var preset = document.querySelector('#preset');
    preset.addEventListener('change', function() {
        if (preset.value === 'chaos') {
            controls.clear();
            controls.add();
            for (var i = 0; i < 31; i++)
                controls.clone();
        } else if (preset.value === 'gentle') {
            while (rossler.solutions.length < 32)
                controls.add();
            rossler.display.rotationd[0] = 0;
            rossler.display.rotationd[1] = 0;
            rossler.display.rotationd[2] = 0.007;
            rossler.display.damping = false;
        } else if (preset.value === 'bendy') {
            while (rossler.solutions.length < 64)
                controls.add();
            controls.set_sigma(0.2);
            controls.set_beta(0.2);
            controls.set_rho(5.7);
            rossler.display.scale = 1 / 65;
        }
        
    });
    var rosslerSelect = document.querySelector('#lorenz');
    rosslerSelect.addEventListener('change', function() {
        if (rosslerSelect.value === 'lorenzselected') {
            window.location.href = 'index.html';
        }
    });

});